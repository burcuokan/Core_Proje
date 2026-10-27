using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
   public class EfSkillDal:GenericRepository<Skill>,ISkillDal
    {
    }
}
