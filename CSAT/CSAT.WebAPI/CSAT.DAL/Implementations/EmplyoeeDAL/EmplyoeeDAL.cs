using CSAT.DAL.Contracts.IEmplyoeeDAL;
using CSAT.DAL.EntityModel;
using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.DAL.Implementations.EmplyoeeDAL
{
   public class EmplyoeeDAL: IEmplyoeeDAL
    {
        public EmplyoeeMstDTO Get(int id)
        {
            try
            {
                EmplyoeeMstDTO EmplyoeeObj = new EmplyoeeMstDTO();
                using (var context = new MJEMEntities())
                {
                    var Emplyoee = context.EmplyoeeMsts.Where(x => (bool)!x.IsDeleted && x.EmplyoeeId == id).FirstOrDefault();
                    return EmplyoeeObj = AutoMapper.Mapper.Map<EmplyoeeMst, EmplyoeeMstDTO>(Emplyoee);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<EmplyoeeMstDTO> GetAll()
        {
            try
            {
                var EmplyoeeList = new List<EmplyoeeMstDTO>();
                using (var context = new MJEMEntities())
                {
                    var Emplyoees = context.EmplyoeeMsts.Where(x => (bool)!x.IsDeleted).ToList();
                    return EmplyoeeList = AutoMapper.Mapper.Map<List<EmplyoeeMst>, List<EmplyoeeMstDTO>>(Emplyoees);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        public string Save(EmplyoeeMstDTO model)
        {
            try
            {
                var EFobjSave = new EmplyoeeMst();
                var Result = "";
                using (var context = new MJEMEntities())
                {
                    if (model.EmplyoeeId > 0)
                    {
                        model.ModifiedBy = 1;// currentUser.UserId;
                        model.ModifiedDate = DateTime.Now;
                        model.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);

                        var Emplyoee = context.EmplyoeeMsts.Where(x => x.EmplyoeeId == model.EmplyoeeId).FirstOrDefault();
                        if (Emplyoee != null)
                        {
                            Emplyoee.EmplyoeeName = model.EmplyoeeName;
                            Emplyoee.MobileNumber = model.MobileNumber;
                            Emplyoee.Address = model.Address;
                            Emplyoee.GovtId = model.GovtId;
                            EFobjSave = context.EmplyoeeMsts.Attach(Emplyoee);
                            context.Entry(Emplyoee).State = EntityState.Modified;
                            Result = "Emplyoee Data Updated Successfully";
                        }

                    }
                    else
                    {
                        model.CreatedBy = 1;///currentUser.UserId;
                        model.CreatedDate = DateTime.Now;
                        model.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);
                        var EFObj = AutoMapper.Mapper.Map<EmplyoeeMstDTO, EmplyoeeMst>(model);
                        EFobjSave = context.EmplyoeeMsts.Add(EFObj);
                        Result = "Emplyoee Data Saved Successfully";


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

                        var Emplyoee = context.EmplyoeeMsts.Where(x => x.EmplyoeeId == id).FirstOrDefault();
                        if (Emplyoee != null)
                        {

                            Emplyoee.ModifiedBy = 1;// currentUser.UserId;
                            Emplyoee.ModifiedDate = DateTime.Now;
                            Emplyoee.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);
                            Emplyoee.IsDeleted = true;
                            var EFobjSave = context.EmplyoeeMsts.Attach(Emplyoee);
                            context.Entry(Emplyoee).State = EntityState.Modified;

                        }

                    }


                    context.SaveChanges();
                    return ("Emplyoee Data Deleted Successfully");

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
