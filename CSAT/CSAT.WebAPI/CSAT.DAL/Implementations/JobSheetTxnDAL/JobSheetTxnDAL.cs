using CSAT.DAL.Contracts.IJobSheetTxnDAL;
using CSAT.DAL.EntityModel;
using CSAT.DAL.Helpers;
using CSAT.DTO;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSAT.DAL.Helpers.DBHelpers;

namespace CSAT.DAL.Implementations.JobSheetTxnDAL
{
    public class JobSheetTxnDAL: IJobSheetTxnDAL
    {
        public JobSheetTxnDTO Get(int id)
        {
            try
            {

                using (var context = new MJEMEntities())
                {
                    JobSheetTxnDTO JobSheetobj = new JobSheetTxnDTO();

                    var Jobsheettxn = context.JobSheetTxns.Where(x => (bool)!x.IsDeleted && x.JobSheetTxnId == id).FirstOrDefault();
                    JobSheetobj= AutoMapper.Mapper.Map<JobSheetTxn, JobSheetTxnDTO>(Jobsheettxn);
                    JobSheetobj.ParentLocationId = context.LocationMsts.Where(x => x.LocationId == JobSheetobj.LocationId).FirstOrDefault().ParentLocationId;
                    var Jobsheettxndet = context.JobSheetTxnDets.Where(x => (bool)!x.IsDeleted && x.JobSheetTxnId == id).ToList();
                    JobSheetobj.JobSheetTxnDet = AutoMapper.Mapper.Map<List<JobSheetTxnDet>, List<JobSheetTxnDetDTO>>(Jobsheettxndet);
                    var LoadBasicvalues=Load();
                    JobSheetobj.JobSheetTxnDet.ForEach(x => { x.VechileList = LoadBasicvalues.Vechiles;x.EmplyoeeList = LoadBasicvalues.Employees;x.DieselFromList = LoadBasicvalues.DiselFrom;
                        x.Date = x.DateTime == null ? DateTime.Now.Date.ToString("dd-MM-yyyy") : x.DateTime.Value.ToString("dd-MM-yyyy");
                    });
                    return JobSheetobj;
                        
                }
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

                using (var context = new MJEMEntities())
                {
                    return
                      context.JobSheetTxns.Where(x => !x.IsDeleted)
                       .Join(context.CustomersMsts.Where(x => !x.IsDeleted), 
                                    JS => JS.CustomerId,customer => customer.CustomerId, 
                                           (A, B) => new
                                                    { JobsheetObj = A, CustomerObj = B })
                       .Join(context.LocationMsts.Where(x => !x.IsDeleted), 
                                    AA => AA.JobsheetObj.LocationId,Lm => Lm.LocationId, 
                                           (AB, C)=> new
                                                    { JSandCstObj = AB, LocationObj = C })
                        .Join(context.LocationMsts.Where(x => !x.IsDeleted),
                                    D => D.LocationObj.ParentLocationId, DD => DD.LocationId, 
                                            (C, D) => new
                                                    { JSTxnCst = C, Location = D })

                        .Select(x=>new JobSheetTxnDTO
                        {
                            Customer=x.JSTxnCst.JSandCstObj.CustomerObj.CustomerName,
                            Location=x.JSTxnCst.LocationObj.LocationName,
                            ParentLocation=x.Location.LocationName,
                            JobSheetTxnId = x.JSTxnCst.JSandCstObj.JobsheetObj.JobSheetTxnId



                        }).ToList();
                        
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string Save(JobSheetTxnDTO model)
        {
            try
            {
                var EFobjSave = new JobSheetTxn();
                var Result = "";
                var newId = 0;
                using (var context = new MJEMEntities())
                {
                    if (model.JobSheetTxnId > 0)
                    {
                        model.ModifiedBy = 1;// currentUser.UserId;
                        model.ModifiedDate = DateTime.Now;
                        model.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);

                        var Jobsheettxn = context.JobSheetTxns.Where(x => x.JobSheetTxnId == model.JobSheetTxnId).FirstOrDefault();
                        if (Jobsheettxn != null)
                        {
                            Jobsheettxn.CustomerId = model.CustomerId;
                            Jobsheettxn.LocationId = model.LocationId;
                            EFobjSave = context.JobSheetTxns.Attach(Jobsheettxn);
                            newId = model.JobSheetTxnId;
                            context.Entry(Jobsheettxn).State = EntityState.Modified;
                            Result = "Job sheet Updated Successfully";
                            context.SaveChanges();
                        }

                    }
                    else
                    {
                        model.CreatedBy = 1;///currentUser.UserId;
                        model.CreatedDate = DateTime.Now;
                        model.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);
                        var EFObj = AutoMapper.Mapper.Map<JobSheetTxnDTO, JobSheetTxn>(model);
                        EFobjSave = context.JobSheetTxns.Add(EFObj);
                        context.SaveChanges();
                        Result = "Job sheet Saved Successfully";
                        newId = EFObj.JobSheetTxnId;
                    }

                   

                    //ChildSave & Update
                    model.JobSheetTxnDet.ForEach(x => x.JobSheetTxnId = newId);
                    ChildTransactionSaveandUpdate(model.JobSheetTxnDet);
                    return Result;


                }
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
                using (var context = new MJEMEntities())
                {
                    if (id > 0)
                    {

                        var Jobsheet = context.JobSheetTxns.Where(x => x.JobSheetTxnId == id).FirstOrDefault();
                        if (Jobsheet != null)
                        {

                            Jobsheet.ModifiedBy = 1;// currentUser.UserId;
                            Jobsheet.ModifiedDate = DateTime.Now;
                            Jobsheet.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);
                            Jobsheet.IsDeleted = true;
                            var EFobjSave = context.JobSheetTxns.Attach(Jobsheet);
                            context.Entry(Jobsheet).State = EntityState.Modified;

                        }

                    }


                    context.SaveChanges();
                    return ("Job sheet Deleted Successfully");

                }
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
                
               
                using (var context = new MJEMEntities())
                {
                   var CustomerLOV = context.CustomersMsts.Where(x =>!x.IsDeleted).ToList();
                   var ParentLocationLOV = context.LocationMsts.Where(x => x.ParentLocationId == 8 &&x.LocationId!=8 && !x.IsDeleted).ToList();
                   var EmplyoeeLOV = context.EmplyoeeMsts.Where(x => !x.IsDeleted).ToList();
                   var VechileLOV = context.VechileMsts.Where(x =>  !x.IsDeleted)
                                    .Join(context.MJEMSysLovs.Where(x => !x.IsDeleted), A => A.VehcileType,B=>B.LovId,(A,B)=>
                                    new {Veh=A,Lov=B }).Select(x=>new VechileMstDTO
                                    {
                                        VechileId=x.Veh.VechileId,
                                        VechileNumber=x.Lov.FieldValue+" - "+x.Veh.VechileNumber
                                    })
                                    .ToList();
                   var DiselTypeLOV = context.MJEMSysLovs.Where(x => !x.IsDeleted && x.LovKey=="DiselProviderType").ToList();

                    CustomerLOV.Add(new CustomersMst { CustomerId = 0, CustomerName = "Select" });
                    ParentLocationLOV.Add(new LocationMst { LocationId = 0, LocationName = "Select" });
                    EmplyoeeLOV.Add(new EmplyoeeMst { EmplyoeeId = 0, EmplyoeeName = "Select" });
                    VechileLOV.Add(new VechileMstDTO { VechileId = 0, VechileNumber = "Select",VehcileType=0 });
                    DiselTypeLOV.Add(new MJEMSysLov { LovId = 0, FieldValue = "Select" });

                    var LoadValues = new JobSheetTxnDTO
                    {
                        Customers = AutoMapper.Mapper.Map<List<CustomersMst>, List<CustomerMstDTO>>(CustomerLOV),
                        ParentLocations = AutoMapper.Mapper.Map<List<LocationMst>, List<LocationMstDTO>>(ParentLocationLOV),
                        Employees= AutoMapper.Mapper.Map<List<EmplyoeeMst>, List<EmplyoeeMstDTO>>(EmplyoeeLOV),
                        Vechiles = VechileLOV,
                        DiselFrom = AutoMapper.Mapper.Map<List<MJEMSysLov>, List<MJEMSysLovDTO>>(DiselTypeLOV),
                    };
                   
                    return LoadValues;
                }
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
                var LoadValues = new List<LocationMstDTO>();
                using (var context = new MJEMEntities())
                {
                    var LoadValue = context.LocationMsts.Where(x => x.ParentLocationId == Location.ParentLocationId && !x.IsDeleted).ToList();
                    LoadValues = AutoMapper.Mapper.Map<List<LocationMst>, List<LocationMstDTO>>(LoadValue);
                    LoadValues.Add(new LocationMstDTO { LocationId = 0, LocationName = "Select" });
                    return LoadValues.OrderBy(x => x.LocationId).ToList();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ChildTransactionSaveandUpdate(List<JobSheetTxnDetDTO> det)

        {
            try
            {
                var update = det.Where(x => x.JobTxnSheetDetId > 0).ToList();
                var insert = det.Where(x => x.JobTxnSheetDetId == 0).ToList();
                var EFobjSave = new JobSheetTxnDet();
                using (var context = new MJEMEntities())
                {

                if (insert.Count() > 0)
                {
                        foreach (var obj in insert)
                        {
                       
                                obj.CreatedBy = 1;///currentUser.UserId;
                                obj.CreatedDate = DateTime.Now;
                                obj.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);
                                var EFObj = AutoMapper.Mapper.Map<JobSheetTxnDetDTO, JobSheetTxnDet>(obj);
                                EFobjSave = context.JobSheetTxnDets.Add(EFObj);
                        }

                    }
                if (update.Count() > 0)
                {
                        foreach (var obj in update)
                        {

                            
                                obj.ModifiedBy = 1;// currentUser.UserId;
                                obj.ModifiedDate = DateTime.Now;
                                obj.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);

                                var Jobsheettxndet = context.JobSheetTxnDets.Where(x => x.JobTxnSheetDetId == obj.JobTxnSheetDetId).FirstOrDefault();
                                if (Jobsheettxndet != null)
                                {
                                Jobsheettxndet.EmplyoeeId = obj.EmplyoeeId;
                                Jobsheettxndet.VechileId = obj.VechileId;
                                Jobsheettxndet.JobSheetTxnId = obj.JobSheetTxnId;
                                Jobsheettxndet.DateTime = obj.DateTime;
                                Jobsheettxndet.RunningHours = obj.RunningHours;
                                Jobsheettxndet.Advance = obj.Advance;
                                Jobsheettxndet.Rate = obj.Rate;
                                Jobsheettxndet.DriverBeta = obj.DriverBeta;
                                Jobsheettxndet.DieselFrom = obj.DieselFrom;
                                Jobsheettxndet.DieselLtr = obj.DieselLtr;
                                Jobsheettxndet.DieselRate = obj.DieselRate;
                                Jobsheettxndet.IsDeleted = obj.IsDeleted;



                                EFobjSave = context.JobSheetTxnDets.Attach(Jobsheettxndet);
                                context.Entry(Jobsheettxndet).State = EntityState.Modified;
                                   
                                }

                        }

                    }
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public DataSet PrintPdf(int id)
        {
            DBHelpers oDBHelper = new DBHelpers();
            Parameters[] colParameters = null;
            try
            {


                string paramPrefix = oDBHelper.SetPrefixParam();

                colParameters = new Parameters[]
                                   {
                                        new  Parameters( paramPrefix+"Id",  id ),
                                       
                                   };

                //oDBHelper = new DBHelpers();

                return  oDBHelper.DataAdapter(CommandType.StoredProcedure, "USP_JobTxnExport", colParameters);
                
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
    }
}

