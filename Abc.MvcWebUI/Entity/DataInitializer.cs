using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var  kategoriler = new List<Category>()
            {
                new Category(){Name="Kamera",Description="Kamera Ürünleri"},
                new Category(){Name="Bilgisayar",Description="Bilgisayar Ürünleri"},
                new Category(){Name="Tv Goruntu",Description="Tv Görüntü Ürünleri"},
                new Category(){Name="Telefon",Description="Telefon Ürünleri"},
                new Category(){Name="Beyaz Eşya",Description="Beyaz Eşya Ürünleri"}

            };
            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();



            var urunler = new List<Product>()
            {
                new Product(){ Name="Sony Kamera ",Description="Abdalın yağı çok olursa gah borusuna çalar, gah gerisine",Price=1200,Stock=555, IsApproved=true, CategoryId=1, isHome=true, Image="1.jpg"},
                new Product(){ Name="Canon Kamera",Description="Acındırırsan arsız olur; acıktırırsan hırsız olur",Price=1500,Stock=666, IsApproved=false, CategoryId=1, isHome=true, Image="5.jpg"},
                new Product(){ Name="Kodak Kamera",Description="Aç koyma hırsız olur, çok söyleme yüzsüz olur, çok değme arsız olur.",Price=1888,Stock=152, IsApproved=true, CategoryId=1, isHome=true, Image="2.jpg"},
                new Product(){ Name="FujiFilm Kamera",Description="Alçak yerde yatma sel alır, yüksek yere yatma yel alır.",Price=1255,Stock=687, IsApproved=false, CategoryId=1, isHome=true, Image="3.jpg"},
                new Product(){ Name="GoPro Kamera",Description="Ana kızına taht kurar, kız bahtı kocadan arar",Price=1555,Stock=453, IsApproved=true, CategoryId=1, isHome=true, Image="1.jpg"},
                new Product(){ Name="Preo Kamera",Description="Analık usta, yumağı ufak yapar; çocuklar usta, ekmeği çifte kapar.",Price=1697,Stock=968, IsApproved=false, CategoryId=1, isHome=true, Image="2.jpg"},

                new Product(){ Name="asus",Description="Acemi marangozun talaşı tahtasından çok olur.",Price=1244,Stock=445, IsApproved=true, CategoryId=2, isHome=true, Image="3.jpg"},
                new Product(){ Name="lenova",Description="Aptal ata binerse bey oldum sanır, şalgam aşa girerse yağ oldum sanır.",Price=4555,Stock=687, IsApproved=true, CategoryId=2, isHome=true, Image="1.jpg"},
                new Product(){ Name="Hp",Description="Arabanın ön tekerleği nereden geçerse art tekerleği de oradan geçer.",Price=3664,Stock=783, IsApproved=false, CategoryId=2, isHome=true, Image="4.jpg"},
                new Product(){ Name="Acer",Description="Arsız neden arlanır, çul da giyer sallanır.",Price=7865,Stock=964, IsApproved=true, CategoryId=2, isHome=true,Image="2.jpg"},
                new Product(){ Name="Monster",Description="Ateş düzene girdi hamur bitti, işler düzene girdi ömür bitti.",Price=1526,Stock=669, IsApproved=true, CategoryId=2, isHome=true, Image="4.jpg"},
                new Product(){ Name="Apple",Description="Ayıyı fırına atmışlar, yavrusunu ayağının altına almış",Price=9854,Stock=485, IsApproved=false, CategoryId=2, isHome=true, Image="1.jpg"},

                new Product(){ Name="Samsung Tv",Description="Ayıyı fırına atmışlar, yavrusunu ayağının altına almış",Price=1254,Stock=432, IsApproved=false, CategoryId=3, isHome=true, Image="5.jpg"},
                new Product(){ Name="Sony Tv",Description="Ağustos'tan sonra ekilen darıdan, bal vermeyen arıdan, sabah erkeğinden sonra kalkan karıdan hayır gelmez",Price=1456,Stock=789, IsApproved=true, CategoryId=3, isHome=true, Image="4.jpg"},
                new Product(){ Name="LG Tv",Description="At olacak tay yürüyüşünden belli olur",Price=1478,Stock=568, IsApproved=false, CategoryId=3, isHome=true, Image="5.jpg"},
                new Product(){ Name="Vestel Tv",Description="Bir avuç altının olacağına bir avuç toprağın olsun",Price=1365,Stock=789, IsApproved=true, CategoryId=3, isHome=true, Image="1.jpg"},
                new Product(){ Name="Axen Tv",Description="Bir deli kuyuya bir taş atar, kırk akıllı çıkaramaz",Price=1522,Stock=452, IsApproved=true, CategoryId=3, isHome=true, Image="3.jpg"},
                new Product(){ Name="Philips Tv",Description="Bir dirhem gümüşün üstünde oturmaya bir kantar göt gerek",Price=1499,Stock=566, IsApproved=false, CategoryId=3, isHome=true, Image="1.jpg"},


                new Product(){ Name="Apple",Description="Cömert derler maldan ederler, yiğit derler candan ederler",Price=1499,Stock=789, IsApproved=true, CategoryId=4, isHome=true, Image="1.jpg"},
                new Product(){ Name="Samsung",Description="Deme dostuna, der dostuna. Bir gün olur tuz basarlar postuna",Price=1299,Stock=435, IsApproved=false, CategoryId=4, isHome=true, Image="2.jpg"},
                new Product(){ Name="Huawei",Description="Derdin yoksa söylen, borcun yoksa evlen",Price=1799,Stock=687, IsApproved=false, CategoryId=4, isHome=true, Image="1.jpg"},
                new Product(){ Name="Xiaomi",Description="Dünyada tasasız baş bostan korkuluğunda bulunur",Price=1899,Stock=156, IsApproved=true, CategoryId=4, isHome=true, Image="5.jpg"},
                new Product(){ Name="Oppo",Description="El yumruğu yemeyen kendi yumruğunu değirmen taşı sanır",Price=1999,Stock=456, IsApproved=true, CategoryId=4, isHome=true, Image="3.jpg"},
                new Product(){ Name="Nokia",Description="Kazanırsan dost kazan, düşmanı anan da doğurur",Price=1899,Stock=456, IsApproved=false, CategoryId=4, isHome=true, Image="1.jpg"},

                new Product(){ Name="Çamaşır Makinesi",Description="Rüzgârlı havanın kuytusu,yağmurlu havanın uykusu",Price=1488,Stock=456, IsApproved=true, CategoryId=5, isHome=true, Image="4.jpg"},
                new Product(){ Name="Bulaşık Makinesi",Description="Malını yemesini bilmeyen zengin her gün züğürttür",Price=2896,Stock=786, IsApproved=true, CategoryId=5, isHome=true, Image="1.jpg"},
                new Product(){ Name="Buz Dolabı",Description="Lafla pilav pişerse deniz kadar yağı benden",Price=3658,Stock=786, IsApproved=true, CategoryId=5, isHome=true, Image="3.jpg"},
                new Product(){ Name="Fırın",Description="Veresiye şarap içen, iki kere sarhoş olur",Price=8957,Stock=456, IsApproved=true, CategoryId=5, isHome=true, Image="1.jpg"},
                new Product(){ Name="Ocak",Description="Zemheride yoğurt isteyen cebinde bir inek taşır",Price=1478,Stock=876, IsApproved=true, CategoryId=5, isHome=true, Image="4.jpg"},
                new Product(){ Name="Ankastre",Description="Ucuna bak bezini al, anasına bak kızını al.",Price=3658,Stock=967, IsApproved=false, CategoryId=5, isHome=true, Image="1.jpg"}

            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();


            base.Seed(context);
        }

    }
}