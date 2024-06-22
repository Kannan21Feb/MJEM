using CSAT.DAL;
using CSAT.DTO;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.BLL
{
    public class FeedbackServicesBLL
    {
        /// <summary>
        /// Customer Satisfaction Survey object passed  
        /// Create survey object 
        /// </summary>
        /// <param name="objSurvey"></param>
        public void Save(SurveyDTO objSurvey)
        {
            
            FeedbackServicesDAL feedbackServicesDAL = new FeedbackServicesDAL();
            try
            {
                if (!CSATValidation(objSurvey))
                {
                    feedbackServicesDAL.Save(objSurvey);
                }
            
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                feedbackServicesDAL = null;
            }
        }

        public DataSet Load(int Id, string ShortKey)
        {
            
            FeedbackServicesDAL feedbackServicesDAL = new FeedbackServicesDAL();
            try
            {
                DataSet ds =feedbackServicesDAL.Load(Id,ShortKey);
              
                return ds;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            finally
            {
                feedbackServicesDAL = null;
            }
        }

        /// <summary>
        /// Customer Satisfaction Survey object passed  
        /// Create survey object 
        /// </summary>
        /// <param name="objSurvey"></param>
        public void Save(ComplaintDTO objComplaint)
        {
            
            FeedbackServicesDAL feedbackServicesDAL = new FeedbackServicesDAL();
            try
            {
                if (!CSATValidation(objComplaint))
                {
                    feedbackServicesDAL.Save(objComplaint);
                }
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                feedbackServicesDAL = null;
            }
        }

        public byte[] GenerateQRCode()
        {
            
            FeedbackServicesDAL feedbackServicesDAL = new FeedbackServicesDAL();
            try
            {
                
               return feedbackServicesDAL.GenerateQRCode();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                feedbackServicesDAL = null;
            }
        }

        public string GenerateShorterURL()
        {
            
            FeedbackServicesDAL feedbackServicesDAL = new FeedbackServicesDAL();
            try
            {
               
                return feedbackServicesDAL.GenerateShorterURL();
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            finally
            {
                feedbackServicesDAL = null;
            }
        }


        public string GetImageSrc()
        {
           
            FeedbackServicesDAL feedbackServicesDAL = new FeedbackServicesDAL();
            try
            {
                
                return feedbackServicesDAL.GetImageSrc();
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            finally
            {
                feedbackServicesDAL = null;
            }
        }

        #region CSAT Business validation 
        public bool CSATValidation(dynamic objCSAT)
        {
            var _bResult = false;

            Type type = objCSAT.GetType();
            var className = type.Name;

            PropertyInfo[] propertyInfo = type.GetProperties();

            foreach (PropertyInfo pInfo in propertyInfo)
            {
                if ((pInfo.Name == "UserAreaID") || (pInfo.Name == "CssRateID" && className == "SurveyDTO")
                    || (pInfo.Name == "ComplaintCategoryID" && className == "ComplaintDTO"))
                {
                    var userid = Convert.ToInt32(objCSAT.GetType().GetProperty(pInfo.Name).GetValue(objCSAT, null));
                    var res = CommonValidation.MinIntValidation(userid);
                    if (res) { _bResult = res; }
                }
                if (pInfo.Name == "Comments")
                {
                    var comments =Convert.ToString(objCSAT.GetType().GetProperty(pInfo.Name).GetValue(objCSAT, null));
                    var res = CommonValidation.stringValidation(comments);
                    if (res) { _bResult = res; }
                }

            }
            return _bResult;
        }
        #endregion
    }
}
