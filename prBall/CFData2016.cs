namespace prBall
{
    class CFData2016
    {
        public string Title { get; set; }
        public int ArticleID { get; set; }
        public int GorodID { get; set; }
        public int VuzID { get; set; }
        public int FakultetID { get; set; }

        public bool? TypeObuchDnevnoe { get; set; }
        public bool? TypeObuchZaochnoe { get; set; }
        public bool? TypeObuchDistanc { get; set; }
        public bool? TypeObuchSokrasch { get; set; }

        public decimal? PrBallDnevnBudget { get; set; }
        public decimal? PrBallDnevnPlatnoe { get; set; }
        public decimal? PrBallZaochnBudget { get; set; }
        public decimal? PrBallZaochnPlatn { get; set; }
        public decimal? PrBallSokrDnevnBudg { get; set; }
        public decimal? PrBallSokrDnevnPlatn { get; set; }
        public decimal? PrBallSokrZaochBudget { get; set; }
        public decimal? PrBallSokrZaochPlatnoe { get; set; }
        public decimal? PrBallDistBudget { get; set; }
        public decimal? PrBallDistPlatnoe { get; set; }

        public bool? CertRusskiy { get; set; }
        public bool? CertMatemat { get; set; }
        public bool? CertHimia { get; set; }
        public bool? CertIstoriaBelorus { get; set; }
        public bool? CertInostrYazik { get; set; }
        public bool? CertSpecEkzamen { get; set; }
        public bool? CertBiologia { get; set; }

        public bool? CertFizika { get; set; }
        public bool? CertObschestvoved { get; set; }
        public bool? CertVsemirIstoria { get; set; }
        public bool? CertGeografia { get; set; }
        public bool? CertProfSobesed { get; set; }

        public int NapravleniePodgotovki { get; set; }
    }
}
