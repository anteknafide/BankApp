using System.Text.RegularExpressions;

namespace BankApp
{ 
    class Klient

    {
        string imie;
        string nazwisko;
        string numerKonta;
        string pin; // 4 cyfrowy
        int stanKonta; // w groszach

        /// <summary>
        /// Tworzy obiekt nowego klienta z pustym kodem pin i zerowym stanem konta
        /// </summary>
        /// <param name="imie">Imię</param>
        /// <param name="nazwisko">Nazwisko</param>
        /// <param name="numerKonta">Numer konta</param>
        public Klient(string imie, string nazwisko, string numerKonta)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.numerKonta = numerKonta;
            this.stanKonta = 0;
            this.pin = "";
        }

        /// <summary>Pobierz imie klienta</summary>
        public string getImie()
        {
            return imie;
        }

        /// <summary>Pobierz nazwisko klienta</summary>
        public string getNazwisko()
        {
            return nazwisko;
        }

        /// <summary>Pobierz numer konta klienta</summary>
        public string getNumerKonta()
        {
            return numerKonta;
        }
        

        /// <summary>Pobierz stan konta klienta w groszach</summary>
        public int getStanKonta()
        {
            return stanKonta;
        }

        /// <summary>Pobierz PIN</summary>
        public string getPIN()
        {
            return pin;
        }

        /// <summary>
        /// Zmiana stanu konta
        /// </summary>
        /// <param name="zmiana">Wartość zmiany w groszach dodatnia dla wpłaty, ujemna dla wypłaty</param>
        /// <example>klient.setStanKonta(1000)</example>
        /// <example>klient.setStanKonta(-500)</example>
        /// <returns>Bool dla powodzenia operacji</returns>
        /// 
        
        public bool setStanKonta(int zmiana)
        {
            if (this.stanKonta + zmiana >= 0) //sprawdza czy stan konta nie będzie ujemny po zmianie
            {
                this.stanKonta = this.stanKonta + zmiana;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Zmiana numeru PIN
        /// </summary>
        /// <param name="zmiana">Nowy PIN, ograniczony do 4 cyfr</param>
        /// <example>klient.setPin("1234")</example>
        /// <returns>Bool dla powodzenia operacji</returns>
        public bool setPin(string nowyPIN)
        {
            if ((nowyPIN.Length == 4) && Regex.IsMatch(nowyPIN, @"^\d+$")) //sprawdza czy PIN sklada sie z 4 cyfr
            {
                this.pin = nowyPIN;
                return true;
            }
            else return false;
        }
        
    }
}