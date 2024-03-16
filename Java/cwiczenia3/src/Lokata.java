import java.util.Random;

public class Lokata extends Konto {
    OkresLokaty okres;
    static int numeracja=500;

    double oprocentowanie;

    public Lokata(Wlasciciel wlasc, OkresLokaty okres)  {
        super(wlasc);
        this.okres = okres;
        numeracja++;
        Random random=new Random();
        oprocentowanie=random.nextDouble()*6;
    }

    @Override
    public String toString() {
        return super.toString()+" "+okres.toString()+" oprocentowanie: "+Math.round(oprocentowanie * 100.0) / 100.0;
    }
}
