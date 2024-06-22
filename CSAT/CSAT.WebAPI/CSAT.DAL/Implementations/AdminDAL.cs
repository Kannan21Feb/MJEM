using CSAT.DAL.Helpers;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSAT.DAL.Helpers.DBHelpers;

namespace CSAT.DAL
{
    public class AdminDAL : IAdminDAL
    {
        #region Private member variables.
        private readonly DBHelpers _oDBHelper;
        private Parameters[] colParameters = null;

        #endregion
        #region Public constructor.
        /// <summary>
        /// Public constructor.
        /// </summary>
        public AdminDAL(DBHelpers oDBHelpers)
        {
            _oDBHelper = oDBHelpers;
        }
        #endregion
        public DataSet LoadDashboard()
        {
            
            Parameters[] colParameters = null;

            try
            {
                colParameters = new Parameters[]
                                    {
                                    };
                DataSet ds = _oDBHelper.DataAdapter(CommandType.StoredProcedure, "usp_Dashboard", colParameters);
               
                return ds;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            finally
            {
                colParameters = null;
            }
        }
    }
}
