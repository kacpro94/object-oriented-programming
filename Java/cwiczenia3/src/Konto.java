public class Konto {
    Wlasciciel wlasciciel;
    public double saldo;
    long numerKonta;
    static int bnk;
    static{ bnk=100;}
    public Konto(){}
    public Konto(Wlasciciel wlasc)
    {
        this.wlasciciel = wlasc;
        this.saldo=0;
        this.numerKonta=++bnk;
    }
    public String toString()
    {
        return numerKonta+" "+wlasciciel.getNazwa()+" "+saldo;
    }

    public void wplac(double kwota) throws Exception {
        if(kwota>0) {
            saldo = saldo + kwota;
        }
        else throw new Exception("kwota ujemna");

    }

    public boolean MoznaWyplacic(double kwota){
        return saldo>kwota;
    }

    public void wyplac(double kwota) throws Exception {
        if(kwota<0) throw new Exception("kwota ujemna");
        else {
            if (MoznaWyplacic(kwota)) {
                saldo = saldo - kwota;
            } else {
                throw new BrakPieniedzyExcepion("nie mozna wyplacic");
            }
        }
    }

    public static void Przelej(Konto k1,Konto k2,double kwota) throws Exception {
        if(k1.MoznaWyplacic(kwota)){
            k1.wyplac(kwota);
            k2.wplac(kwota);
        }
    }

    class BrakPieniedzyExcepion extends Exception {
        public BrakPieniedzyExcepion(String s)
        {
            // Call constructor of parent Exception
            super(s);
        }
    }



}
