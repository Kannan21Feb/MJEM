using CSAT.DAL;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.BLL
{
   public class AdminBLL : IAdminBLL
    {
        #region Private member variables.
        private readonly AdminDAL _adminDAL;
        #endregion

        #region Public constructor.
        /// <summary>
        /// Public constructor.
        /// </summary>
        public AdminBLL(AdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }
        #endregion


        /// <summary>
        ///  Get the record in database for Customer and facility.
        /// </summary>
        /// <returns></returns>
        public DataSet LoadDashboard()
        {
            
            try
            {
                var ds = _adminDAL.LoadDashboard();
                

                return ds;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }
    }
}
