using RealEstate.BusinessLayer.Abstract;
using RealEstate.DataAccessLayer.Abstract;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BusinessLayer.Concrete
{
    public class MemberMenager : IMemberService
    {
        IMemberDAL _memberDAL;

        public MemberMenager(IMemberDAL memberDAL)
        {
            _memberDAL = memberDAL;
        }

        public void TDelete(Member entity)
        {
            _memberDAL.Delete(entity);
        }

        public Member TGetByID(int id)
        {
            return _memberDAL.GetByID(id);
        }

        public List<Member> TGetList()
        {
            return _memberDAL.GetList();
        }

        public void TInsert(Member entity)
        {

            _memberDAL.Insert(entity);
        }

        public void TUpdate(Member entity)
        {
            _memberDAL.Update(entity);
        }
    }
}
