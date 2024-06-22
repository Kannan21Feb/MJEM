using CSAT.DAL.Contracts.ILocationDAL;
using CSAT.DAL.EntityModel;
using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.DAL.Implementations.LocationDAL
{
    public class LocationDAL: ILocationDAL
    {
        public LocationMstDTO Get(int id)
        {
            try
            {

                using (var context = new MJEMEntities())
                {
                    LocationMstDTO LocationObj = new LocationMstDTO();
                   
                        var Location = context.LocationMsts.Where(x => (bool)!x.IsDeleted && x.LocationId == id).FirstOrDefault();
                       return LocationObj = AutoMapper.Mapper.Map<LocationMst, LocationMstDTO>(Location);
                   
                  
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<LocationMstDTO> GetAll()
        {
            try
            {

                using (var context = new MJEMEntities())
                {
                    return  
                        (context.LocationMsts.Where(x => (bool)!x.IsDeleted && x.ParentLocationId!=0  )
                        .Join(context.LocationMsts.Where(x => !x.IsDeleted && x.LocationId != 8 && x.ParentLocationId != 8), A => A.LocationId, B => B.ParentLocationId, (A, B) => new
                        {  ParentLocation = A, Location = B }).Select(x => new LocationMstDTO
                        {
                            ParentLocationName=x.ParentLocation.LocationName,
                            LocationName = x.Location.LocationName,
                            LocationId=x.Location.LocationId

                        }).ToList());



                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string Save(LocationMstDTO model)
        {
            try
            {
                var EFobjSave = new LocationMst();
                var Result = "";
                using (var context = new MJEMEntities())
                {
                    if (model.LocationId > 0)
                    {
                        model.ModifiedBy = 1;// currentUser.UserId;
                        model.ModifiedDate = DateTime.Now;
                        model.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);

                        var Vechile = context.LocationMsts.Where(x => x.LocationId == model.LocationId).FirstOrDefault();
                        if (Vechile != null)
                        {
                            Vechile.LocationName = model.LocationName;
                            Vechile.ParentLocationId = model.ParentLocationId;
                            EFobjSave = context.LocationMsts.Attach(Vechile);
                            context.Entry(Vechile).State = EntityState.Modified;
                            Result = "Location Data Updated Successfully";
                        }

                    }
                    else
                    {
                        model.CreatedBy = 1;///currentUser.UserId;
                        model.CreatedDate = DateTime.Now;
                        model.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);
                        var EFObj = AutoMapper.Mapper.Map<LocationMstDTO, LocationMst>(model);
                        EFobjSave = context.LocationMsts.Add(EFObj);
                        Result = "Location Data Saved Successfully";


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

                        var Vechile = context.LocationMsts.Where(x => x.LocationId == id).FirstOrDefault();
                        if (Vechile != null)
                        {

                            Vechile.ModifiedBy = 1;// currentUser.UserId;
                            Vechile.ModifiedDate = DateTime.Now;
                            Vechile.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);
                            Vechile.IsDeleted = true;
                            var EFobjSave = context.LocationMsts.Attach(Vechile);
                            context.Entry(Vechile).State = EntityState.Modified;

                        }

                    }


                    context.SaveChanges();
                    return ("Location Data Deleted Successfully");

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<LocationMstDTO> Load()
        {
            try
            {
                var LoadValues = new List<LocationMstDTO>();
                using (var context = new MJEMEntities())
                {
                    var LoadValue = context.LocationMsts.Where(x => x.ParentLocationId ==8 && x.LocationId != 8 && !x.IsDeleted).ToList();
                    LoadValues = AutoMapper.Mapper.Map<List<LocationMst>, List<LocationMstDTO>>(LoadValue);
                    LoadValues.Add(new LocationMstDTO {LocationId=0,LocationName="Select" });
                    return LoadValues.OrderBy(x=>x.LocationId).ToList();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
