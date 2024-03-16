import java.util.ArrayList;

public class Bank {

    String nazwa;
    ArrayList<Konto> listaKont;

    public Bank(String nazwa) {
        this.nazwa = nazwa;
        listaKont=new ArrayList<>();
    }

    public void utworzKonto(Konto k){
        listaKont.add(k);
    }

    public void usunKonto(long numer){
        for(Konto k:listaKont){
            if(k.numerKonta==numer){
                listaKont.remove(k);
            }
        }
    }

    public Konto podajKonto(long numer) throws Exception {
        for(Konto k:listaKont){
            if(k.numerKonta==numer){
                return k;
            }
        }
        throw new Exception("nie ma takiego konta");
    }

    public Konto podajWlasciciel(String nazwa) throws Exception {
        for(Konto k:listaKont){
            if(k.wlasciciel.getNazwa()==nazwa){
                return k;
            }
        }
        throw new Exception("nie ma takiego konta");
    }

    public double saldoBanku(){
        double suma=0;
        for(Konto k:listaKont){

            suma=suma+k.saldo;

        }
        return suma;
    }

    @Override
    public String toString() {
       String nazwa= "nazwa:" +this.nazwa+"\n";
       for(Konto k :listaKont){
           nazwa=nazwa+k.toString()+"\n";
       }
       return nazwa;

    }
}
