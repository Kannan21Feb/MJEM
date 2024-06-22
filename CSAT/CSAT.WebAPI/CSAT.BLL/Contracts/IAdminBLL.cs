using System.Data;

namespace CSAT.BLL
{
    public interface IAdminBLL
    {
        #region Interface member methods.
        /// <summary>
        ///  Get the record in database for Customer and facility.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        DataSet LoadDashboard();

        #endregion
    }
}
