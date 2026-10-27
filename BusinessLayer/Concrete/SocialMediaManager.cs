using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void TAdd(EntityLayer.Concrete.SocialMedia t)
        {
            _socialMediaDal.Insert(t);
        }

        public void TDelete(EntityLayer.Concrete.SocialMedia t)
        {
            _socialMediaDal.Delete(t);
        }

        public EntityLayer.Concrete.SocialMedia TGetByID(int id)
        {
           return _socialMediaDal.GetByID(id);
        }

        public List<EntityLayer.Concrete.SocialMedia> TGetList()
        {
            return _socialMediaDal.GetList();
        }

        public List<EntityLayer.Concrete.SocialMedia> TGetListbyFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(EntityLayer.Concrete.SocialMedia t)
        {
            _socialMediaDal.Update(t);
        }
    }
}
