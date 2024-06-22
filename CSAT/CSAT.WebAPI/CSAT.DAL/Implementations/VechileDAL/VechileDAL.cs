using CSAT.DAL.Contracts.IVechileDAL;
using CSAT.DAL.EntityModel;
using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CSAT.DAL.Implementations.VechileDAL
{
   public class VechileDAL: IVechileDLL
    {
        public VechileMstDTO Get(int id)
        {
            try
            {
                
                using (var context = new MJEMEntities())
                {
                    var Vechile = context.VechileMsts.Where(x => (bool)!x.IsDeleted && x.VechileId == id).FirstOrDefault();
                    return  AutoMapper.Mapper.Map<VechileMst, VechileMstDTO>(Vechile);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<VechileMstDTO> GetAll()
        {
            try
            {
                
                using (var context = new MJEMEntities())
                {
                    return   (context.VechileMsts.Where(x => (bool)!x.IsDeleted)
                                    .Join(context.MJEMSysLovs.Where(x=>!x.IsDeleted),A=>A.VehcileType,B=>B.LovId,(A,B)=>new
                                    {Vechile=A,VechileType=B})
                                    .Select(x => new VechileMstDTO
                                    {
                                        VechileNumber=x.Vechile.VechileNumber,
                                        VehcileTypeValue=x.VechileType.FieldValue,
                                        VechileId=x.Vechile.VechileId

                                    }).ToList());
                    

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string Save(VechileMstDTO model)
        {
            try
            {
                var EFobjSave = new VechileMst();
                var Result = "";
                using (var context = new MJEMEntities())
                {
                    if (model.VechileId > 0)
                    {
                        model.ModifiedBy = 1;// currentUser.UserId;
                        model.ModifiedDate = DateTime.Now;
                        model.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);

                        var Vechile = context.VechileMsts.Where(x => x.VechileId == model.VechileId).FirstOrDefault();
                        if (Vechile != null)
                        {
                            Vechile.VechileNumber = model.VechileNumber;
                            Vechile.VehcileType= model.VehcileType;
                            EFobjSave = context.VechileMsts.Attach(Vechile);
                            context.Entry(Vechile).State = EntityState.Modified;
                            Result = "Vechile Data Updated Successfully";
                        }

                    }
                    else
                    {
                        model.CreatedBy = 1;///currentUser.UserId;
                        model.CreatedDate = DateTime.Now;
                        model.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);
                        var EFObj = AutoMapper.Mapper.Map<VechileMstDTO, VechileMst>(model);
                        EFobjSave = context.VechileMsts.Add(EFObj);
                        Result = "Vechile Data Saved Successfully";


                    }

                    context.SaveChanges();
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

                        var Vechile = context.VechileMsts.Where(x => x.VechileId == id).FirstOrDefault();
                        if (Vechile != null)
                        {

                            Vechile.ModifiedBy = 1;// currentUser.UserId;
                            Vechile.ModifiedDate = DateTime.Now;
                            Vechile.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);
                            Vechile.IsDeleted = true;
                            var EFobjSave = context.VechileMsts.Attach(Vechile);
                            context.Entry(Vechile).State = EntityState.Modified;

                        }

                    }


                    context.SaveChanges();
                    return ("Vechile Data Deleted Successfully");

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }

        public List<MJEMSysLovDTO> Load()
        {
            try
            {
                var LoadValues = new  List<MJEMSysLovDTO>();
                using (var context = new MJEMEntities())
                {
                    var LoadValue = context.MJEMSysLovs.Where(x => x.LovKey == "VechileType" && !x.IsDeleted).ToList();
                     LoadValue.Add(new MJEMSysLov { LovId = 0, FieldValue = "Select", Remarks = "Select" });
                     LoadValues = AutoMapper.Mapper.Map<List<MJEMSysLov>, List<MJEMSysLovDTO>>(LoadValue);
                    return LoadValues.OrderBy(x => x.LovId).ToList();

                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
