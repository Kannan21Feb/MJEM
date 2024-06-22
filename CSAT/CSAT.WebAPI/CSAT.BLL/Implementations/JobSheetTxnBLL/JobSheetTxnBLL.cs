using CSAT.BLL.Contracts.IJobSheetTxnBLL;
using CSAT.DAL.Implementations.JobSheetTxnDAL;
using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.BLL.Implementations.JobSheetTxnBLL
{
  public  class JobSheetTxnBLL:IJobSheetTxnBLL
    {
        private readonly JobSheetTxnDAL _JobSheetTxnDAL = new JobSheetTxnDAL();

        /// <summary>

        /// <returns></returns>

        public JobSheetTxnDTO Get(int id)
        {

            try
            {
                return _JobSheetTxnDAL.Get(id);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string Save(JobSheetTxnDTO obj)
        {

            try
            {
                return _JobSheetTxnDAL.Save(obj);




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string Delete(int id)
        {

            try
            {
                return _JobSheetTxnDAL.Delete(id);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<JobSheetTxnDTO> GetAll()
        {

            try
            {
                return _JobSheetTxnDAL.GetAll();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public JobSheetTxnDTO Load()
        {
            try
            {
                return _JobSheetTxnDAL.Load();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public DataSet PrintPdf(int id)
        {
            try 
	        {
                return _JobSheetTxnDAL.PrintPdf(id);
            }
	        catch (Exception ex)
	        {

		        throw ex;
	        }
        }
        public List<LocationMstDTO> SubLocation(LocationMstDTO Location)
        {
            try
            {
                return _JobSheetTxnDAL.SubLocation(Location);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       

    }
}
