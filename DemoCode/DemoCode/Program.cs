// See https://aka.ms/new-console-template for more information
using DemoCode;
using DemoCode.Factory;

Console.WriteLine("Hello, World!");
//Personne personne = new Personne();
//Developpeur developpeur = new Developpeur("julien");
//developpeur.Parler();
//Personne dev = new Developpeur("julien");
//dev.Parler();
//Exception.crash("tes");

Menu();

static void Menu()
{
    int[] tableau = Enumerable.Range(1, 50).ToArray();
    System.Console.WriteLine("                      <<<<<MENU>>>>>\n--------recherche dans un tableau ordonné tapez 1"
    + "\n--------compte à rebours tapez 2\n--------calcul de somme tapez 3\n--------Pattern Factory : Créer un instrument tapez 4");
    //System.Console.ReadLine();
    var result = System.Console.ReadLine();
    switch (result)
    {
        case "1":
            rechercherValeur.RechercheDansTableauOrdonne(12, tableau);
            Menu();
            break;
        case "2":
            Compteur.décompteur(150);
            Menu();
            break;
        case "3":
            Calcul.somme(50, 5, out int resultat,10);
            System.Console.WriteLine("ça fait {0}", resultat);
            Menu();
            break;
        case "4":
            Console.WriteLine($"Choisir un instrument\nViolon : 1\nPiano : 2");
            var instru = Console.ReadLine();
            TestPatternFactory(instru);
            //if (!string.IsNullOrEmpty(instru))
            //{
            //    TestPatternFactory(instru);
            //    Menu();
            //}
            break;
    }
}
static void TestPatternFactory(string instruChoisi)
{
    if (instruChoisi == "1")
    {
        ViolonFactory violonFactory = new ViolonFactory();
        IInstrument InstruViolon = violonFactory.CreateInstrument();
        InstruViolon.Jouer();
        Menu();
    }
    PianoFactory pianoFactory = new PianoFactory();
    IInstrument InstruPiano = pianoFactory.CreateInstrument();
    InstruPiano.Jouer();
    Menu();
}