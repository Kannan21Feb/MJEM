using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace CSAT.DAL.Helpers
{
    /// <summary>
    ///Description	    :	This class used for CRUD operartions using any data providers like MS Sql Server, MY Sql, etc...
    //Author			:	
    ///Date				:	25 April 2019
    ///Input			:	
    ///OutPut			:	
    ///Comments			:	
    /// </summary>
    public class DBHelpers
    {
        #region DECLARATIONS 

        private DbProviderFactory oFactory;
        private DbConnection oConnection;
        private ConnectionState oConnectionState;
        public DbCommand oCommand;
        private DbParameter oParameter;
        private DbTransaction oTransaction;
        private bool mblTransaction;

        private static string S_CONNECTION = Convert.ToString(ConfigurationManager.ConnectionStrings["SqlClientProvider"]); //ConfigurationManager.AppSettings["DATA.CONNECTIONSTRING"];
        private static string S_PROVIDER = "System.Data.SqlClient";
        private static readonly int I_SetDataProvider = Convert.ToInt32(ConfigurationManager.AppSettings["SetDataProvider"]);

        #endregion

        #region ENUMERATORS 

        public enum TransactionType : uint
        {
            Open = 1,
            Commit = 2,
            Rollback = 3
        }

        public enum DataAccessProviderTypes
        {
            SqlServer = 0, // Default data provider
            MySql = 1,
            SqLite = 2,
            PostgreSql = 3
        }


        #endregion

        #region STRUCTURES 

        /// <summary>
        ///Description	    :	This function is used to Execute the Command
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	
        ///OutPut			:	
        ///Comments			:	
        /// </summary>
        public struct Parameters
        {
            public string ParamName;
            public object ParamValue;
            public ParameterDirection ParamDirection;

            public Parameters(string Name, object Value, ParameterDirection Direction)
            {
                ParamName = Name;
                ParamValue = Value;
                ParamDirection = Direction;
            }

            public Parameters(string Name, object Value)
            {
                ParamName = Name;
                ParamValue = Value;
                ParamDirection = ParameterDirection.Input;
            }
        }

        #endregion

        #region CONSTRUCTOR 

        public DBHelpers()
        {
            /** Here get data provider based on  default provider **/
            //oFactory = DbProviderFactories.GetFactory(S_PROVIDER);
        }

        #endregion

        #region CONNECTIONS 

        /// <summary>
        ///Description	    :	This function is used to Open Database Connection
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	NA
        ///OutPut			:	NA
        ///Comments			:	
        /// </summary>
        public void EstablishFactoryConnection()
        {
            /*
            // This check is not required as it will throw "Invalid Provider Exception" on the contructor itself.
            if (0 == DbProviderFactories.GetFactoryClasses().Select("InvariantName='" + S_PROVIDER + "'").Length)
                throw new Exception("Invalid Provider");
            */

            SetDbProviderFactories();
            oConnection = oFactory.CreateConnection();

            if (oConnection.State == ConnectionState.Closed)
            {
                oConnection.ConnectionString = S_CONNECTION;
                oConnection.Open();
                oConnectionState = ConnectionState.Open;
            }
        }

        public void SetDbProviderFactories()
        {
            var paramPrefix = string.Empty;
            if (DataAccessProviderTypes.SqlServer.GetHashCode() == I_SetDataProvider)
            {
                S_CONNECTION = Convert.ToString(ConfigurationManager.ConnectionStrings["SqlClientProvider"]);
                S_PROVIDER = "System.Data.SqlClient";
            }
            else if (DataAccessProviderTypes.MySql.GetHashCode() == I_SetDataProvider)
            {
                S_CONNECTION = Convert.ToString(ConfigurationManager.ConnectionStrings["MySqlClientProvider"]); 
                S_PROVIDER = "MySql.Data.MySqlClient";
            }

            oFactory = DbProviderFactories.GetFactory(S_PROVIDER);
        }

        /// <summary>
        ///Description	    :	This function is used to Close Database Connection
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	NA
        ///OutPut			:	NA
        ///Comments			:	
        /// </summary>
        public void CloseFactoryConnection()
        {
            //check for an open connection            
            try
            {
                if (oConnection.State == ConnectionState.Open)
                {
                    oConnection.Close();
                    oConnectionState = ConnectionState.Closed;
                }
            }
            catch (DbException oDbErr)
            {
                //catch any SQL server data provider generated error messag
                throw new Exception(oDbErr.Message);
            }
            catch (System.NullReferenceException oNullErr)
            {
                throw new Exception(oNullErr.Message);
            }
            finally
            {
                if (null != oConnection)
                    oConnection.Dispose();
            }
        }

        #endregion

        #region TRANSACTION 

        /// <summary>
        ///Description	    :	This function is used to Handle Transaction Events
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	Transaction Event Type
        ///OutPut			:	NA
        ///Comments			:	
        /// </summary>
        public void TransactionHandler(TransactionType veTransactionType)
        {
            switch (veTransactionType)
            {
                case TransactionType.Open:  //open a transaction
                    try
                    {
                        oTransaction = oConnection.BeginTransaction();
                        mblTransaction = true;
                    }
                    catch (InvalidOperationException oErr)
                    {
                        throw new Exception("@TransactionHandler - " + oErr.Message);
                    }
                    break;

                case TransactionType.Commit:  //commit the transaction
                    if (null != oTransaction.Connection)
                    {
                        try
                        {
                            oTransaction.Commit();
                            mblTransaction = false;
                        }
                        catch (InvalidOperationException oErr)
                        {
                            throw new Exception("@TransactionHandler - " + oErr.Message);
                        }
                    }
                    break;

                case TransactionType.Rollback:  //rollback the transaction
                    try
                    {
                        if (mblTransaction)
                        {
                            oTransaction.Rollback();
                        }
                        mblTransaction = false;
                    }
                    catch (InvalidOperationException oErr)
                    {
                        throw new Exception("@TransactionHandler - " + oErr.Message);
                    }
                    break;
            }

        }

        #endregion

        #region COMMANDS 

        #region STRUCTURE BASED PARAMETER ARRAY 

        /// <summary>
        ///Description	    :	This function is used to Prepare Command For Execution
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	Transaction, Command Type, Command Text, 2-Dimensional Parameter Array
        ///OutPut			:	NA
        ///Comments			:	
        /// </summary>
        private void PrepareCommand(bool blTransaction, CommandType cmdType, string cmdText, Parameters[] cmdParms)
        {

            if (oConnection.State != ConnectionState.Open)
            {
                oConnection.ConnectionString = S_CONNECTION;
                oConnection.Open();
                oConnectionState = ConnectionState.Open;
            }

            oCommand = oFactory.CreateCommand();
            oCommand.Connection = oConnection;
            oCommand.CommandText = cmdText;
            oCommand.CommandType = cmdType;

            if (blTransaction)
                oCommand.Transaction = oTransaction;

            if (null != cmdParms)
                CreateDBParameters(cmdParms);
        }

        #endregion

        #endregion

        #region PARAMETER METHODS 

        #region STRUCTURE BASED 

        /// <summary>
        ///Description	    :	This function is used to Create Parameters for the Command For Execution
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	2-Dimensional Parameter Array
        ///OutPut			:	NA
        ///Comments			:	
        /// </summary>
        private void CreateDBParameters(Parameters[] colParameters)
        {
            for (int i = 0; i < colParameters.Length; i++)
            {
                Parameters oParam = (Parameters)colParameters[i];

                oParameter = oCommand.CreateParameter();
                oParameter.ParameterName = oParam.ParamName;
                oParameter.Value = oParam.ParamValue;
                oParameter.Direction = oParam.ParamDirection;
                oCommand.Parameters.Add(oParameter);

            }
        }

        #endregion

        #endregion

        #region EXCEUTE METHODS 
        #region STRUCTURE BASED PARAMETER ARRAY 

        /// <summary>
        ///Description	    :	This function is used to Execute the Command
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	Command Type, Command Text, Parameter Structure Array, Clear Parameters
        ///OutPut			:	Count of Records Affected
        ///Comments			:	
        /// </summary>
        public int ExecuteNonQuery(CommandType cmdType, string cmdText, Parameters[] cmdParms, bool blDisposeCommand)
        {
            try
            {

                EstablishFactoryConnection();
                PrepareCommand(false, cmdType, cmdText, cmdParms);
                return oCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (blDisposeCommand && null != oCommand)
                    oCommand.Dispose();
                CloseFactoryConnection();
            }
        }

        /// <summary>
        ///Description	    :	This function is used to Execute the Command
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	Command Type, Command Text, Parameter Structure Array
        ///OutPut			:	Count of Records Affected
        ///Comments			:	Overloaded method. 
        /// </summary>
        public int ExecuteNonQuery(CommandType cmdType, string cmdText, Parameters[] cmdParms)
        {
            return ExecuteNonQuery(cmdType, cmdText, cmdParms, true);
        }

        /// <summary>
        ///Description	    :	This function is used to Execute the Command
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	Transaction, Command Type, Command Text, Parameter Structure Array, Clear Parameters
        ///OutPut			:	Count of Records Affected
        ///Comments			:	
        /// </summary>
        public int ExecuteNonQuery(bool blTransaction, CommandType cmdType, string cmdText, Parameters[] cmdParms, bool blDisposeCommand)
        {
            try
            {

                PrepareCommand(blTransaction, cmdType, cmdText, cmdParms);
                return oCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (blDisposeCommand && null != oCommand)
                    oCommand.Dispose();
            }
        }

        /// <summary>
        ///Description	    :	This function is used to Execute the Command
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	Transaction, Command Type, Command Text, Parameter Structure Array
        ///OutPut			:	Count of Records Affected
        ///Comments			:	
        /// </summary>
        public int ExecuteNonQuery(bool blTransaction, CommandType cmdType, string cmdText, Parameters[] cmdParms)
        {
            return ExecuteNonQuery(blTransaction, cmdType, cmdText, cmdParms, true);
        }

        #endregion

        #endregion

        #region READER METHODS 

        #region STRUCTURE BASED PARAMETER ARRAY 

        /// <summary>
        ///Description	    :	This function is used to fetch data using Data Reader	
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	Command Type, Command Text, Parameter AStructure Array
        ///OutPut			:	Data Reader
        ///Comments			:	
        /// </summary>
        public DbDataReader ExecuteReader(CommandType cmdType, string cmdText, Parameters[] cmdParms)
        {

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {

                EstablishFactoryConnection();
                PrepareCommand(false, cmdType, cmdText, cmdParms);
                return oCommand.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {
                CloseFactoryConnection();
                throw ex;
            }
            finally
            {
                if (null != oCommand)
                    oCommand.Dispose();
            }
        }

        #endregion

        #endregion

        #region ADAPTER METHODS 

        #region STRUCTURE BASED PARAMETER ARRAY 

        /// <summary>
        ///Description	    :	This function is used to fetch data using Data Adapter	
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	Command Type, Command Text, 2-Dimensional Parameter Array
        ///OutPut			:	Data Set
        ///Comments			:	
        /// </summary>
        public DataSet DataAdapter(CommandType cmdType, string cmdText, Parameters[] cmdParms)
        {

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            DbDataAdapter dda = null;
            try
            {
                EstablishFactoryConnection();
                dda = oFactory.CreateDataAdapter();
                PrepareCommand(false, cmdType, cmdText, cmdParms);

                dda.SelectCommand = oCommand;
                DataSet ds = new DataSet();
                dda.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (null != oCommand)
                    oCommand.Dispose();
                CloseFactoryConnection();
            }
        }

        #endregion

        #endregion

        #region SCALAR METHODS 

        #region STRUCTURE BASED PARAMETER ARRAY 

        /// <summary>
        ///Description	    :	This function is used to invoke Execute Scalar Method	
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	Command Type, Command Text, 2-Dimensional Parameter Array
        ///OutPut			:	Object
        ///Comments			:	
        /// </summary>
        public object ExecuteScalar(CommandType cmdType, string cmdText, Parameters[] cmdParms, bool blDisposeCommand)
        {
            try
            {
                EstablishFactoryConnection();
                PrepareCommand(false, cmdType, cmdText, cmdParms);
                return oCommand.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (blDisposeCommand && null != oCommand)
                    oCommand.Dispose();
                CloseFactoryConnection();
            }
        }

        /// <summary>
        ///Description	    :	This function is used to invoke Execute Scalar Method	
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	Command Type, Command Text, 2-Dimensional Parameter Array
        ///OutPut			:	Object
        ///Comments			:	Overloaded Method. 
        /// </summary>
        public object ExecuteScalar(CommandType cmdType, string cmdText, Parameters[] cmdParms)
        {
            return ExecuteScalar(cmdType, cmdText, cmdParms, true);
        }

        /// <summary>
        ///Description	    :	This function is used to invoke Execute Scalar Method	
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	Command Type, Command Text, 2-Dimensional Parameter Array
        ///OutPut			:	Object
        ///Comments			:	
        /// </summary>
        public object ExecuteScalar(bool blTransaction, CommandType cmdType, string cmdText, Parameters[] cmdParms, bool blDisposeCommand)
        {
            try
            {

                PrepareCommand(blTransaction, cmdType, cmdText, cmdParms);
                return oCommand.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (blDisposeCommand && null != oCommand)
                    oCommand.Dispose();
            }
        }

        /// <summary>
        ///Description	    :	This function is used to invoke Execute Scalar Method	
        ///Author			:	Prabhakaran S.
        ///Date				:	25 April 2019
        ///Input			:	Command Type, Command Text, 2-Dimensional Parameter Array
        ///OutPut			:	Object
        ///Comments			:	
        /// </summary>
        public object ExecuteScalar(bool blTransaction, CommandType cmdType, string cmdText, Parameters[] cmdParms)
        {
            return ExecuteScalar(blTransaction, cmdType, cmdText, cmdParms, true);
        }

        #endregion

        #endregion


        public string SetPrefixParam()
        {
            var paramPrefix = string.Empty;
            if (DataAccessProviderTypes.SqlServer.GetHashCode() == I_SetDataProvider)
            {
                paramPrefix = "@";
            }
            else if (DataAccessProviderTypes.MySql.GetHashCode() == I_SetDataProvider)
            {
                paramPrefix = "_";
            }

            return paramPrefix;
        }
    }
}
