using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpTask.Models
{

  public class PersonalDetailBL
    {
        public List<PersonalDetail> PersonalDetails()
        {
            PersonalDetailDL db = new PersonalDetailDL();
            return db.personalDetails();
        }
        public bool Create(PersonalDetail personalDetail)
        {
            PersonalDetailDL db = new PersonalDetailDL();
            return db.Create(personalDetail);

        }

        public bool Update(PersonalDetail personalDetail)
        {
            PersonalDetailDL db = new PersonalDetailDL();
            return db.Update(personalDetail);
        }
        public bool Delete(int id)
        {
            PersonalDetailDL db = new PersonalDetailDL();
            return db.Delete(id);
        }
        public PersonalDetail DetailsById(int id)
        {
            PersonalDetailDL db = new PersonalDetailDL();
            return db.DetailsById(id);
        }


    }

}