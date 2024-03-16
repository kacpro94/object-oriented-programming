public class Main {
    public static void main(String[] args) throws Exception {
        Wlasciciel wlasciciel1=new Wlasciciel("szymon","tttt  ss","25-991","tttt");
        Wlasciciel wlasciciel2=new Wlasciciel("mariusz","tttt  ss","43-300","tttt");
        Wlasciciel wlasciciel3=new Wlasciciel("iioosxz","ysss","00-000","tppp");

        System.out.println(wlasciciel1.toString());
        Konto konto1=new Konto(wlasciciel1);
        Konto konto2=new Konto(wlasciciel2);
        System.out.println(konto1.toString());

        konto1.wplac(500);
        System.out.println(konto1.toString());
        Konto.Przelej(konto1,konto2,369);
        System.out.println(konto1.toString());
        System.out.println(konto2.toString());

        Bank bank1=new Bank("OOOO");
        bank1.utworzKonto(konto1);
        bank1.utworzKonto(konto2);


        Lokata lokata1=new Lokata(wlasciciel1,OkresLokaty.roczna);
        System.out.println(lokata1.toString());


        Lokata lokata2=new Lokata(wlasciciel3,OkresLokaty.półroczna);
        bank1.utworzKonto(lokata1);
        bank1.utworzKonto(lokata2);
        System.out.println(bank1.toString());
    }
}
