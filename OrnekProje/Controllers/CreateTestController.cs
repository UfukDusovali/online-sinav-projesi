using OrnekProje.CustomFilter;
using OrnekProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrnekProje.Controllers
{
    [LoginFilter]
    public class CreateTestController : BaseController
    {
       
        private OrnekProjeEntities db = new OrnekProjeEntities();
        public ActionResult Index()
        {
            return View(db.InformationQuestion.ToList());
        }
    
    
        public ActionResult Details(Guid id)
        {
            return View(db.InformationQuestion.Find(id));
        }

    
        public ActionResult Create()
        {
            return View();
        }

 
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                InformationQuestion baslik = new InformationQuestion();
                baslik.Id = Guid.NewGuid();
                baslik.UserId = Guid.Parse("00000000-0000-0000-0000-000000000000");
                baslik.Name = collection["baslik"];
                baslik.Text= collection["textarea"];
                baslik.CreateDate = DateTime.Now;
                db.InformationQuestion.Add(baslik);
                db.SaveChanges();

                #region soru cevap ekleme 1
                // soru cevap ekleme 1
                Question soru1 = new Question();
                soru1.Id = Guid.NewGuid();
                soru1.InforQuestionId = baslik.Id;
                soru1.Name = collection["Soru1"];
                db.Question.Add(soru1);
                db.SaveChanges();

                
                for (int i = 1; i < 5; i++)
                {
                    string deger1 = collection["cevap1"].ToString();
                    string deger2 = collection["s1cevap" + i + ""];

                    if (collection["cevap1"] == collection["s1cevap" + i + ""])
                    {
                        Answer cevap1 = new Answer();
                        cevap1.Id = Guid.NewGuid();
                        cevap1.QuestionId = soru1.Id;
                        cevap1.Name = collection["s1cevap" + i + ""];
                        cevap1.IsTrue = 1;
                        db.Answer.Add(cevap1);
                        db.SaveChanges();
                    }
                    else
                    {
                        Answer cevap1 = new Answer();
                        cevap1.Id = Guid.NewGuid();
                        cevap1.QuestionId = soru1.Id;
                        cevap1.Name = collection["s1cevap" + i + ""];
                        cevap1.IsTrue = 0;
                        db.Answer.Add(cevap1);
                        db.SaveChanges();

                    }

                }
                #endregion

                #region soru cevap ekleme 2
                // soru cevap ekleme 1
                Question soru2 = new Question();
                soru2.Id = Guid.NewGuid();
                soru2.InforQuestionId = baslik.Id;
                soru2.Name = collection["Soru2"];
                db.Question.Add(soru2);
                db.SaveChanges();

                
                for (int i = 1; i < 5; i++)
                {
                    if (collection["cevap2"] == collection["s2cevap" + i + ""])
                    {
                        Answer cevap2 = new Answer();
                        cevap2.Id = Guid.NewGuid();
                        cevap2.QuestionId = soru2.Id;
                        cevap2.Name = collection["s2cevap" + i + ""];
                        cevap2.IsTrue = 1;
                        db.Answer.Add(cevap2);
                        db.SaveChanges();
                    }
                    else
                    {
                        Answer cevap2 = new Answer();
                        cevap2.Id = Guid.NewGuid();
                        cevap2.QuestionId = soru2.Id;
                        cevap2.Name = collection["s2cevap" + i + ""];
                        cevap2.IsTrue = 0;
                        db.Answer.Add(cevap2);
                        db.SaveChanges();

                    }

                }
                #endregion

                #region soru cevap ekleme 3
                // soru cevap ekleme 1
                Question soru3 = new Question();
                soru3.Id = Guid.NewGuid();
                soru3.InforQuestionId = baslik.Id;
                soru3.Name = collection["Soru3"];
                db.Question.Add(soru3);
                db.SaveChanges();

                
                for (int i = 1; i < 5; i++)
                {
                    if (collection["cevap3"] == collection["s3cevap" + i + ""])
                    {
                        Answer cevap3 = new Answer();
                        cevap3.Id = Guid.NewGuid();
                        cevap3.QuestionId = soru3.Id;
                        cevap3.Name = collection["s3cevap" + i + ""];
                        cevap3.IsTrue = 1;
                        db.Answer.Add(cevap3);
                        db.SaveChanges();
                    }
                    else
                    {
                        Answer cevap3 = new Answer();
                        cevap3.Id = Guid.NewGuid();
                        cevap3.QuestionId = soru3.Id;
                        cevap3.Name = collection["s3cevap" + i + ""];
                        cevap3.IsTrue = 0;
                        db.Answer.Add(cevap3);
                        db.SaveChanges();

                    }

                }
                #endregion

                #region soru cevap ekleme 4
                // soru cevap ekleme 1
                Question soru4 = new Question();
                soru4.Id = Guid.NewGuid();
                soru4.InforQuestionId = baslik.Id;
                soru4.Name = collection["Soru4"];
                db.Question.Add(soru4);
                db.SaveChanges();

                
                for (int i = 1; i < 5; i++)
                {
                    if (collection["cevap4"] == collection["s4cevap" + i + ""])
                    {
                        Answer cevap4 = new Answer();
                        cevap4.Id = Guid.NewGuid();
                        cevap4.QuestionId = soru4.Id;
                        cevap4.Name = collection["s4cevap" + i + ""];
                        cevap4.IsTrue = 1;
                        db.Answer.Add(cevap4);
                        db.SaveChanges();
                    }
                    else
                    {
                        Answer cevap4 = new Answer();
                        cevap4.Id = Guid.NewGuid();
                        cevap4.QuestionId = soru4.Id;
                        cevap4.Name = collection["s4cevap" + i + ""];
                        cevap4.IsTrue =0;
                        db.Answer.Add(cevap4);
                        db.SaveChanges();

                    }

                }
                #endregion


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

 
        public ActionResult Edit(Guid id)
        {
            return View(db.InformationQuestion.Find(id));
        }


        [HttpPost]
        public ActionResult Edit(Guid id, InformationQuestion veri)
        {
            try
            {
                InformationQuestion eski = db.InformationQuestion.FirstOrDefault(x=>x.Id==veri.Id);
                db.Entry(eski).CurrentValues.SetValues(veri);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //public ActionResult Delete(Guid id)
        //{
        //    return View();
        //}

    
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            try
            {
                InformationQuestion item = db.InformationQuestion.Find(id);
                db.InformationQuestion.Remove(item);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Exam(Guid id)
        {
            ExamModel em = new ExamModel();
            em.Sinav = db.InformationQuestion.ToList();
            em.Soru = db.Question.ToList();
            em.Cevap = db.Answer.ToList();
            em.TestID = id;

            return View(em);
        }




        public ActionResult icerikal(Guid id)
        {
            string icerik = (string)db.TempQuestion.FirstOrDefault(x => x.Id == id).Text;
            return Json(icerik, JsonRequestBehavior.AllowGet);
        }
    }
}
