using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using CSAT.DTO;
using CSAT.DAL.Helpers;
using static CSAT.DAL.Helpers.DBHelpers;
using System.Data;
using System.Configuration;

namespace CSAT.DAL
{
    public class FeedbackServicesDAL
    {
        readonly int SetDataProvider = Convert.ToInt32(ConfigurationManager.AppSettings["SetDataProvider"]);


        /// <summary>
        /// Customer Satisfaction Survey object will be pass 
        /// Insert survey object 
        /// </summary>
        /// <param name="objSurvey"></param>
        public void Save(SurveyDTO objSurvey)
        {

            DBHelpers oDBHelper = null;
            Parameters[] colParameters = null;

            

            try
            {
                string paramPrefix = SetPrefixParam();

                colParameters = new Parameters[]
                                    {
                                        //new DBHelper.Parameters( paramPrefix+"SurveyID",     objSurvey.SurveyID, ParameterDirection.Output ),
                                        new  Parameters( paramPrefix+"CssRateID",   objSurvey.CssRateID ),
                                        new  Parameters( paramPrefix+"UserAreaID",  objSurvey.UserAreaID ),
                                        new  Parameters( paramPrefix+"Comments",  objSurvey.Comments )
                                    };

                oDBHelper = new DBHelpers();

                oDBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_InsertCSS", colParameters);
                //objSurvey.SurveyID = Int32.Parse((((IDataParameter)oDBHelper.oCommand.Parameters[paramPrefix+"SurveyID"]).Value).ToString());
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                colParameters = null;
                oDBHelper = null;
            }
        }

        /// <summary>
        /// If survey screen, the Id will be pass as "0",If complaint screen Id will be pass as "1"
        /// </summary>
        /// <param name="Id"></param>
        /// <returns> Return DataSet , survey screen return two DataTables , complaint screen return three DataTables</returns>
        public DataSet Load(int Id, string ShortKey)
        {
            
            DBHelpers oDBHelper = null;
            Parameters[] colParameters = null;

            try
            {
                string paramPrefix = SetPrefixParam();
                ShortKey = ShortKey == "null" ? null : ShortKey;
                colParameters = new Parameters[]
                                    {
                                        new  Parameters( paramPrefix+"Id",  Id ),
                                        new  Parameters( paramPrefix+"ShortKey",  ShortKey )
                                    };
                oDBHelper = new DBHelpers();
                DataSet ds = oDBHelper.DataAdapter(CommandType.StoredProcedure, "usp_LoadCSS", colParameters);
                
                return ds;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                oDBHelper = null;
                colParameters = null;
            }
        }

        /// <summary>
        /// Customer Complaint object will be pass 
        /// Insert Complaint object 
        /// </summary>
        /// <param name="objSurvey"></param>
        public void Save(ComplaintDTO objComplaint)
        {

            DBHelpers oDBHelper = null;
            Parameters[] colParameters = null;

            

            try
            {
                string paramPrefix = SetPrefixParam();
                if (objComplaint.ByteData != null)
                {
                    byte[] ByteData = Convert.FromBase64String(objComplaint.ByteData);
                    objComplaint.Attachment = ByteData;
                }

                colParameters = new Parameters[]
                                    {
                                        new  Parameters( paramPrefix+"UserAreaID",  objComplaint.UserAreaID ),
                                        new  Parameters( paramPrefix+"ComplaintCategoryID",   objComplaint.ComplaintCategoryID ),
                                        new  Parameters( paramPrefix+"Comments",  objComplaint.Comments ),
                                        new  Parameters( paramPrefix+"Attachment",  objComplaint.Attachment )
                                    };

                oDBHelper = new DBHelpers();

                oDBHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_InsertComplaint", colParameters);
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                colParameters = null;
                oDBHelper = null;
            }
        }


        public byte[] GenerateQRCode()
        {
            
            QRGenerator oQRCoder = null;
            URLManager oShortURL = null;
            try
            {
                byte[] qrByte = null;
                oQRCoder = new QRGenerator();
                oShortURL = new URLManager();
                var url = Convert.ToString(ConfigurationManager.AppSettings["WebUIURL"]) + oShortURL.GenerateShorterURL();
                qrByte = oQRCoder.GenerateQRCode(url);
               
                return qrByte;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                oQRCoder = null;
                oShortURL = null;
            }
        }

        public string GenerateShorterURL()
        {
           
            URLManager oShortURL = null;
            try
            {
                oShortURL = new URLManager();
                var shortURL = oShortURL.GenerateShorterURL(); // Convert.ToString(ConfigurationManager.AppSettings["WebUIURL"]) + oShortURL.GenerateShorterURL();
                
                return shortURL;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                oShortURL = null;
            }
        }

        public string GetImageSrc()
        {

            
            DBHelpers oDBHelper = null;
            Parameters[] colParameters = null;
            string strBase64Src = string.Empty;
            try
            {
                var companyId = Convert.ToInt32(ConfigurationManager.AppSettings["LogoURL"]);
                string paramPrefix = SetPrefixParam();
                colParameters = new Parameters[]
                                    {
                                        new  Parameters( paramPrefix+"CompanyId",  companyId )
                                    };
                oDBHelper = new DBHelpers();
                var reader = oDBHelper.ExecuteReader(CommandType.StoredProcedure, "usp_GetLogo", colParameters);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        strBase64Src = (string)reader.GetValue(0);
                    }
                }
               
                return  strBase64Src;

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                oDBHelper = null;
                colParameters = null;
            }
        }

        private string SetPrefixParam()
        {
            var paramPrefix = string.Empty;
            if (DataAccessProviderTypes.SqlServer.GetHashCode() == SetDataProvider)
            {
                paramPrefix = "@";
            }
            else if (DataAccessProviderTypes.MySql.GetHashCode() == SetDataProvider)
            {
                paramPrefix = "_";
            }

            return paramPrefix;
        }
    }
}
