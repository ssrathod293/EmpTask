using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpTask.Models;

namespace EmpTask.Models
{
    public class QualificationBL
    {

        public List<Qualification> qualificationsDetail()
        {
            QualificationDL db = new QualificationDL();
            return db.qualificationsDetail();
        }
        public bool CreateQual(Qualification qualification)
        {
            QualificationDL db = new QualificationDL();
             return db.CreateQual(qualification);

        }
        public bool UpdateQual(Qualification qualification)
        {
            QualificationDL db = new QualificationDL();
            return db.UpdateQual(qualification);
        }
        public bool DeleteQual(int id)
        {
            QualificationDL db = new QualificationDL();
            return db.DeleteQual(id);
        }
        public Qualification QualDetailsById(int id)
        {
            QualificationDL db = new QualificationDL();
            return db.QualDetailsById(id);
        }

    }
}