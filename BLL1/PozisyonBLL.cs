﻿using DAL1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL1.DAO;
using DAL1.DTO;

namespace BLL1
{
    public class PozisyonBLL
    {
        public static void PozisyonEkle(POZISYON pz)
        {
            PozisyonDAO.DepartmanEkle(pz);
        }

        public static List<PozisyonDTO> PozisyonGetir()
        {
            return PozisyonDAO.PozisyonGetir();
        }

        public static void PozisyonGuncelle(PozisyonDetayDTO detay, bool control)
        {
            PozisyonDAO.PozisyonGuncelle(detay);
            if (control)
                PersonelDAO.PersonelGuncelle(detay);
        }

        public static void PozisyonSil(int id)
        {
            PozisyonDAO.PozisyonSil(id);
        }
    }
}
