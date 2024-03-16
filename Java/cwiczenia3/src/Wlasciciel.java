public class Wlasciciel {
    public Wlasciciel(String nazwa, String ulica, String kod, String miejscowosc) throws Exception {
        setNazwa(nazwa);
        setKod(kod);
        setMiejscowosc(miejscowosc);
        setUlica(ulica);
    }

    @Override
    public String toString() {
        return getNazwa()+" "+getKod()+" "+getMiejscowosc()+" "+getUlica();
    }

    public String getUlica() {
        return ulica;
    }

    String nazwa;

    public String getKod() {
        return kod;
    }

    public String getMiejscowosc() {
        return miejscowosc;
    }

    String ulica;

    public void setNazwa(String nazwa) throws Exception {

            if (nazwa.length() > 3) {
                for (char c : nazwa.toCharArray()) {
                        if (!Character.isAlphabetic(c)&&!Character.isSpaceChar(c)) {
                            throw new Exception("ggg");

                        }


                }

                this.nazwa = nazwa;
            } else {
                throw new Exception("ddd");

            }

    }

    public void setUlica(String ulica) throws Exception {
        if (ulica.length() > 3) {
            for (char c : ulica.toCharArray()) {
                if (!Character.isAlphabetic(c)&&!Character.isSpaceChar(c)) {
                    throw new Exception("ggg");

                }


            }

            this.ulica = ulica;
        } else {
            throw new Exception("ddd");

        }
    }

    public void setKod(String kod) throws Exception{


                if (!kod.matches("\\d{2}-\\d{3}")) {
                    throw new Exception("ggg");

                }
                else {
                    this.kod=kod;
                }






    }

    public void setMiejscowosc(String miejscowosc) throws Exception {
        if (miejscowosc.length() > 3) {
            for (char c : miejscowosc.toCharArray()) {
                if (!Character.isAlphabetic(c)&&!Character.isSpaceChar(c)) {
                    throw new Exception("ggg");

                }


            }

            this.miejscowosc = miejscowosc;
        } else {
            throw new Exception("ddd");

        }
    }

    String kod;
    String miejscowosc;

    public String getNazwa(){
        return nazwa;
    }






}