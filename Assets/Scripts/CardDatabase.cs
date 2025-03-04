using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EfectosDiccionario;

public class CardDatabase : MonoBehaviour
{
   public static List<Card> cardList = new List<Card>();

    private void Awake()
    {
        //? --- Desactivar de alguna forma las trampas ---
        //! --- CTRL +H, Dioses ---

        cardList.Add(new Card(0, "none", 0 , 0, 0, 0, "none", "none", "", 0 ));

        // Mundo Antiguo (Antes de los dioses)
        cardList.Add(new Card(1, "Yumi", 1, 2, 1, 4, "Una aventurera humana olvidada por el mundo", "N", "Mercenaria", 0));
        cardList.Add(new Card(2, "Lia", 1, 1, 2, 4, "Una aventurera elfa olvidadada por el mundo", "N", "Guerrera", 0));
        cardList.Add(new Card(3, "Pipmos", 1, 3, 1, 2, "Un aventurero mediano olvidado por el mundo", "N", "Bardo", 0));
        cardList.Add(new Card(4, "Phaksa", 1, 2, 2, 3, "Una aventurera demi-humana olvidada por el mundo", "N", "B�rbara", 0));
        cardList.Add(new Card(5, "Daro", 1, 1, 1, 6, "Un aventurero enano olvidado por el mundo", "N", "Hechicero", 0));
        // Mundo Antiguo (Antes de los dioses (Desbloqueo))
         
        // Mundo Antiguo 2 (N�)
        cardList.Add(new Card(6, "N�12 ", 1, 3, 1, 3, "  <sprite name=AlSerDestruido> invoca de forma especial desde tu mano o  <sprite name=Deck>  a N�11", "Chronos", "Guerrera", 0, new List<ActivationType> { ActivationType.OnLeaveField }, new int[2]{ 11, 0 }, new int[2] { 11, 0 },new string[2] { "N�11", "" }, null, null, null, new int[2] {6,0}));

        cardList.Add(new Card(7, "N�11", 2, 1, 4, 4, "  <sprite name=AlSerInvocado> de forma especial crea 2 fichas [soldado de arena] 0/4/1, <sprite name=AlSerDestruido> invoca de forma especial <sprite name=Mano> o  <sprite name=Deck>  a N�10 ", "Chronos", "Invocadora", 0, new List<ActivationType> { ActivationType.OnEnterField, ActivationType.OnLeaveField }, new int[2] { 11,11 }, new int[2] {1,2}, new string[2] {"Soldado de arena"," N�10"}, null, null, null, new int[2] {7,6} ));

        cardList.Add(new Card(8, "N�10", 3, 4, 1, 3, "  <sprite name=AlSerInvocado> de forma especial roba 1 carta, <sprite name=AlSerDestruido> invoca de forma especial desde de tu <sprite name=Mano> o  <sprite name=Deck>  a N�9 ", "Chronos", "Hechicera", 0, new List<ActivationType> { ActivationType.OnEnterField, ActivationType.OnLeaveField }, new int[2] {1,11}, null, new string[2] {"","N�9"}, null, null, null, new int[2] {0,6}));

        cardList.Add(new Card(9, "N�9", 4, 8, 1, 1, "  <sprite name=AlSerInvocado> de forma especial destruye 1 elegido del rival con 3 de ataque o 3 de defensa, <sprite name=AlSerDestruido> invoca de forma especial <sprite name=Mano> o  <sprite name=Deck>  a N�8", "Chronos", "P�cara", 0, new List<ActivationType> { ActivationType.OnEnterField, ActivationType.OnLeaveField }, new int[2] {2,11}, null, new string[2] {"","N�8"},null, null, null, new int[2] {4,6}, new int[2] {3,0}, new int[2] {3,0})); 
        
        cardList.Add(new Card(10, "N�8", 5, 6, 2, 4, "  <sprite name=AlSerInvocado> de forma especial inflije 1 de da�o a todos los elegidos enemigos, <sprite name=AlSerDestruido> invoca de forma especial <sprite name=Mano> o  <sprite name=Deck>  a N�7", "Chronos", "Mercenaria", 0, new List<ActivationType> { ActivationType.OnEnterField, ActivationType.OnLeaveField }, new int[2] {6,11}, new int[2] {99,1}, new string[2] {"", "N�7"}, null, null, null, new int[2] {4,6}, null, null, new int[2] {1,0}));
        
        cardList.Add(new Card(11, "N�7", 6, 9, 1, 6, "  <sprite name=AlSerInvocado> de forma especial destruye todos los elegidos heridos, <sprite name=AlSerDestruido> invoca de forma especial <sprite name=Mano> o  <sprite name=Deck>  a N�6", "Chronos", "Mercenaria", 0, new List<ActivationType> { ActivationType.OnEnterField, ActivationType.OnLeaveField })); //TODO
        
        cardList.Add(new Card(12, "N�6", 7, 10, 1, 4, "  <sprite name=AlSerInvocado> de forma especial inflije 6 de da�o a un elegido, <sprite name=AlSerDestruido> invoca de forma especial <sprite name=Mano> o  <sprite name=Deck>  a N�5", "Chronos", "Exploradora", 0, new List<ActivationType> { ActivationType.OnEnterField, ActivationType.OnLeaveField }, new int[2] {6,11}, null, new string[2] {"", "N�5"}, null, null, null, new int[2] {4,6}, null, null, new int[2] {6,0}));
        
        cardList.Add(new Card(13, "N�5", 8, 7, 5, 5, "  <sprite name=AlSerInvocado> de forma especial reduce a 1 la defensa de todos los elegidos rivales, <sprite name=AlSerDestruido> invoca de forma especial <sprite name=Mano> o  <sprite name=Deck>  a N�4", "Chronos", "Guerrera", 0, new List<ActivationType> { ActivationType.OnEnterField, ActivationType.OnLeaveField }, new int[2] {5,11}, new int[2] {99, 1}, new string[2] {"","N�4" }, null, null, null, new int[2] {4,6}, null, new int[2] {0,-99}));
        
        cardList.Add(new Card(14, "N�4", 9, 5, 10, 10, "  <sprite name=AlSerInvocado> de forma especial destruye a todos los elegidos con 1 de defensa, <sprite name=AlSerDestruido> invoca de forma especial <sprite name=Mano> o  <sprite name=Deck>  a N�3", "Chronos", "Curandera", 0, new List<ActivationType> { ActivationType.OnEnterField, ActivationType.OnLeaveField }, new int[2] {2,11}, new int[2] {99,1}, new string[2] {"", "N�3"}, null, null, null, new int[2] {4,6 }, null, new int[2] {1,0})); 
        
        cardList.Add(new Card(15, "N�3", 10, 12, 6, 9, "  <sprite name=AlSerInvocado> de forma especial destruye tantos elegidos hasta que quede uno en cada campo, <sprite name=AlSerDestruido> invoca de forma especial <sprite name=Mano> o  <sprite name=Deck>  a N�2", "Chronos", "B�rbara", 0, new List<ActivationType> { ActivationType.OnEnterField, ActivationType.OnLeaveField })); //TODO
        
        cardList.Add(new Card(16, "N�2", 11, 11, 10, 9, "  <sprite name=AlSerInvocado> de forma especial busca una carta trampa N� y a�adela a <sprite name=Mano>, <sprite name=AlSerDestruido> invoca de forma especial <sprite name=Mano> o  <sprite name=Deck>  a N�2", "Chronos", "Exploradora", 0, new List<ActivationType> { ActivationType.OnEnterField, ActivationType.OnLeaveField }, new int[2] {1,11}, null, new string[2] {"N�", "N�2"}, new string[2] {"Trampa", ""})); // TODO efecto 1
        
        cardList.Add(new Card(17, "N�1", 12, 12, 12, 12, "  <sprite name=AlSerInvocado> de forma especial gasta todo tu mana y transformalo en mana de chronos, esta carta no puede ser seleccionada por efectos, al final de cada ronda recupera todo su HP", "Chronos", "Guerrera", 0, new List<ActivationType> { ActivationType.OnEnterField, ActivationType.OnEndTurn }, new int[2] {8,6}, new int[2] {99,1}, new string[2] {"", "N�1"}, null, new string[2] {"Chronos", ""}, null, new int[2] {0,4}, null, null, new int[2] {0,99}));

        cardList.Add(new Card(18, "�ltimo esfuerzo N�", 2, 0, 0, 0, "Destruye un elegido N� despu�s destruye un elegido del rival, despu�s de activar el efecto no puedes invocar elegidos que no sean N� ", "Chronos", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[2] {2,2}, null, new string[2] {"N�", ""}, new string[2] {"Elegido", "Elegido"}, null, null, new int[2] {4,4} ));

        cardList.Add(new Card(19, "Retirada N�",2, 0, 0, 0, "Devuelve al  <sprite name=Deck>  una carta N� en tu cementerio, roba una carta", "Chronos", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[2] {13,1}, null, new string[2] {"N�", ""}));

        cardList.Add(new Card(20, "Regreso N�", 4, 0, 0, 0, "<sprite name=AlSerDestruido> una elegida N�, invoca del cementerio una N� distinta a la que se acaba de enviar", "Chronos", "Trampa", 0)); //TODO: 

        cardList.Add(new Card(21, "Plan de contenci�n N�", 1, 0, 0, 0, "<sprite name=AlSerDestruido> una elegida N�, envia al  <sprite name=Deck>  del cementerio 1 elegida N�", "Chronos", "Trampa", 0)); //TODO: 



        // Mundo Antiguo 3 (Defensores del futuro)
        cardList.Add(new Card(22, "Lyriel", 3, 4, 2, 3, "  <sprite name=AlSerInvocado> inflije 1HP de da�o a un elegido", "Chronos", "P�cara", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] {6}, new int[1] {1}, null, null, null, null, new int[1] {8}, new int[1])); 

        cardList.Add(new Card(23, "Sol", 3, 2, 1, 12, "Por cada HP que le falte aumenta su ataque en 1", "Chronos", "Luchador", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] {10})); //TODO

        cardList.Add(new Card(24, "Zolbo", 2, 1, 1, 4, "  <sprite name=AlSerInvocado> restaura el HP al completo de cualquier elegido", "Chronos", "Curandero", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] {6}, new int[1] {1}, null, null, null, null, new int[1] {2}, null, null, new int[1] {100} ));
        
        cardList.Add(new Card(25, "Emma", 5, 5, 2, 4, " <sprite name=AlSerInvocado> roba una carta", "Chronos", "Mercenaria", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] {1}, new int[1] {1}));
        
        cardList.Add(new Card(26, "Leathen", 2, 1, 1, 1, "  <sprite name=AlSerInvocado> toma el control de un elegido rival, <sprite name=AlSerDestruido> devuelve el control del elegido a su propietario", "Chronos", "Bardo", 0, new List<ActivationType> { ActivationType.OnEnterField, ActivationType.OnLeaveField })); //TODO
        
        cardList.Add(new Card(27, "Arwen", 2, 1, 3, 4, "  <sprite name=AlSerInvocado> cura 2PV un elegido", "N", "Curandera", 0, new List<ActivationType> { ActivationType.OnEnterField}, new int[1] {6}, new int[1] {1}, null, null, null, null, new int[1] {2}, null, null, new int[1] {2}));



        // Mundo Antiguo 4 (Siervos N�)
        cardList.Add(new Card(28, "Klea", 1, 2, 2, 2, "<sprite name=AlSerInvocado> busca una N�1 <sprite name=Deck>", "Chronos", "Guerrera", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] { 1 }, new int[1] { 1 }, new string[1] { "N�1" }, null, null, null, new int[1] { 1 }));
        
        cardList.Add(new Card(29, "Kachal", 6, 2, 1, 5, "<sprite name=AlSerInvocado> invoca una ficha Chakal 5/1/2", "Chronos", "", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] { 11 }, new int[1] { 1 }, new string[1] { "Chakal" }, null, null, null, new int[1] { 1 }));
        
        cardList.Add(new Card(30, "Elcrieri", 8, 8, 2, 6, "Cada vez que ataque roba una carta", "Chronos", "", 0, new List<ActivationType> { ActivationType.OnAttack }, new int[1] { 1 }, new int[1] { 1 }, new string[1] { "" }, null, null, null, new int[1] { 1 }));

        cardList.Add(new Card(31, "ShadowStep", 2, 4, 1, 1, "<sprite name=AlSerInvocado> reduce la defensa a 0 de un elegido rival", "Chronos", "P�caro", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] { 5 }, new int[1] { 1 }, new string[1] { "" }, null, null, null, new int[1] { 0 }));
        
        cardList.Add(new Card(32, "Dahila", 3, 1, 4, 4, "Si un elegido fuera a ser destruido puedes destruir esta en su lugar", "Chronos", "", 0)); //TODO

        cardList.Add(new Card(33, "Celine", 6, 4, 4, 6, "Al final del turno todos los elegidos reciben 1 de da�o", "Chronos", "", 0, new List<ActivationType> { ActivationType.OnEndTurn }, new int[1] { 6 }, new int[1] { 100 }, new string[1] { "" }, null, null, null, new int[1] { 1 }));

        cardList.Add(new Card(34, "Gumi", 4, 1, 4, 10, "Si el jugador rival recibe da�o aumenta el ataque de esta carta en esa cantidad hasta el final de ese turno", "Chronos", "", 0)); //TODO

        cardList.Add(new Card(35, "Amaro", 1, 5, 1, 1, "<sprite name=AlSerInvocado> destruye un elegido con 1 de defensa, si no puede esta carta es destruida", "Chronos", "", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[2] { 2, 2 }, new int[2] { 1, 1 }, new string[2] { "", "Amaro" }, null, null, null, new int[2] { 1, 0 }));
        
        cardList.Add(new Card(36, "��igo", 2, 3, 2, 3, "<sprite name=AlSerInvocado> reduce el ataque de un elegido a la mitad", "Chronos", "", 0)); //TODO

        cardList.Add(new Card(37, "Aul", 10, 10, 4, 10, "Si dos o mas elegidos son destruidos por el efecto de una carta puedes invocarla gratuitamente", "Chronos", "", 0)); //TODO

        cardList.Add(new Card(38, "Olivia", 7, 1, 10, 10, "<sprite name=AlSerInvocado> destruye una carta trampa", "Chronos", "", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] { 2 }, new int[1] { 1 }, new string[1] { "" }, new string[1] { "Trampa" }, null, null, new int[1] { 0 }));
        
        cardList.Add(new Card(39, "C�firo", 6, 6, 6, 6, "No puede ser destruido por efectos de elegidos", "Chronos", "", 0)); //TODO

        // Mundo Antiguo 5
        cardList.Add(new Card(40, "Rana Mercante", 1, 1, 1, 1, "Una vez por ronda puedes descartar 2 cartas para robar 1", "Dana", "Mercader", 0, new List<ActivationType> { ActivationType.OncePerTurn }));
        
        cardList.Add(new Card(41, "Reglas antiguas", 2, 0, 0, 0, "Elimina todos los manas de los dioses", "N", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField })); //TODO

        cardList.Add(new Card(42, "�ltimo recurso", 5, 0, 0, 0, "Si tu vida es 1, obten 20 de mana", "Miknit", "M�gica", 0)); //TODO

        cardList.Add(new Card(43, "Vuelta a lo b�sico", 1, 0, 0, 0, "Transforma todo el mana de los dioses a mana", "N", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField })); //TODO

        cardList.Add(new Card(44, "�ltimo esfuerzo", 1, 0, 0, 0, "Cuando un elegido vaya a ser destruido mantenlo a 1 de vida", "Dana", "Trampa", 0)); //TODO

        cardList.Add(new Card(45, "Castigo divino", 5, 0, 0, 0, "Destruye todos los elegidos en el campo", "Etse", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] { 2 }, new int[1] { 100 }, new string[1] { "" }, null, null, null, new int[1] { 0 }));


        // Revoluci�n Steampunk (La creacion de K.R.I.S)
        cardList.Add(new Card(46, "Orion Bolt", 1, 1, 1, 2, "<sprite name=AlSerInvocado> a�ade K.R.I.S a <sprite name=Mano>", "Miknit", "Artificiero", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] { 1 }, new int[1] { 1 }, new string[1] { "K.R.I.S" }, null, null, null, new int[1] { 1 }));

        cardList.Add(new Card(47, "Martyn Bolt", 2, 1, 1, 1, "<sprite name=AlSerDestruido> roba dos cartas", "Miknit", "Artificiero", 0, new List<ActivationType> { ActivationType.OnLeaveField }, new int[1] { 1 }, new int[1] { 2 }, null, null, null, null, new int[1] { 2 }));
        
        cardList.Add(new Card(48, "Ren Bolt", 5, 3, 2, 2, "Si K.R.I.S esta en el campo puedes invocar este elegido de forma especial desde el cementerio, al hacerlo aumenta el ataque de K.R.I.S en 1", "Miknit", "Artificiero", 0)); //TODO
        
        cardList.Add(new Card(49, "Elen Bolt", 3, 6, 3, 3, "Si K.R.I.S es seleccionado como efecto puedes descartar esta carta y negar ese efecto", "Miknit", "Artificiera", 0)); //TODO
        
        cardList.Add(new Card(50, "Leo Bolt", 4, 1, 4, 3, "  <sprite name=AlSerInvocado>, si tienes a K.R.I.S en la mano, reduce su coste a la mitad", "Miknit", "Artificiero", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        
        cardList.Add(new Card(51, "Nora Bolt", 6, 5, 2, 6, "  <sprite name=AlSerInvocado> si Kris Bolt o K.R.I.S estan en el campo puedes buscar una carta que mencione a uno de los dos  <sprite name=Deck> y a�adirla a tu mano ", "Miknit", "Artificiera", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        
        cardList.Add(new Card(52, "K.R.I.S", 10, 10, 10, 10, "Si esta en posici�n de defensa los elegidos enemigos solo pueden atacarle a el", "N", "Robot", 0)); //TODO

        cardList.Add(new Card(53, "Electric field", 1, 0, 0, 0, "Aumenta el ataque de todos los elegidos Bolt y K.R.I.S en 1, si no hay al menos 1 Bolt en campo al finalizar el turno es destruida", "Miknit", "Dominio", 0)); //TODO
        
        cardList.Add(new Card(54, "Plan Bolt", 3, 0, 0, 0, "Si tienes 1 Bolt en el campo, 1 en el cementerio y 1 en la mano puedes invocar a K.R.I.S", "N", "M�gica", 0)); //TODO
        
        cardList.Add(new Card(55, "Eureka!", 5, 0, 0, 0, "Puedes equipar hasta 6 elegidos Bolt con nombres diferentes a K.R.I.S, este gana 1 de defensa y 2 de HP por cada uno", "Miknit", "M�gica", 0)); //TODO
        // Revoluci�n Steampunk 2 (Mec�nica Fant�stica y Artefactos Extaordianrios)
        cardList.Add(new Card(56, "Kris Bolt", 5, 8, 1, 3, "Cuando es tu turno duplica su ATK, cuando es el turno del rival reduce su DEF a la mitad", "Miknit", "Artificiero", 0, new List<ActivationType> { ActivationType.OnStartTurn, ActivationType.OnEndTurn }));

        cardList.Add(new Card(57, "Valette Bleck", 4, 5, 2, 2, "<sprite name=AlSerInvocado> roba una carta de equipo, una vez por turno puedes destruir esta para destruir un elegido del rival", "Chronos", "Tiradora", 0, new List<ActivationType> { ActivationType.OnEnterField, ActivationType.OncePerTurn }, new int[2] { 1, 2 }, new int[2] { 1, 1 }, new string[2] { "Equipo", "" }, null, null, null, new int[2] { 1, 1 }));

        cardList.Add(new Card(58, "Nara", 3, 1, 2, 8, "Puede tener hasta 8 cartas equipadas", "Dana", "Mercenaria", 0)); //TODO
       
        cardList.Add(new Card(59, "B.S.B-G.A.P-103", 9, 8, 16, 12, "Cada vez que destruye un elegido rival aumenta en 1 todas sus estad�sticas", "Murgu", "Robot", 0, new List<ActivationType> { ActivationType.OnDestroyCard }));

        cardList.Add(new Card(60, "Bateria de Atem", 4, 0, 0, 0, "El elegido equipado con esto puede atacar dos veces por turno", "Dana", "Equipo", 0)); //TODO
     
        cardList.Add(new Card(61, "Lia", 4, 0, 0, 0, "Disminuye en 1 el ataque, <sprite name=AlSerDestruido> invoca en el campo del poseedor de la carta una ficha Lia 9/0/1", "Dana", "Equipo", 0)); //TODO
        
        cardList.Add(new Card(62, "Pistola Kelsier", 2, 0, 0, 0, "Cuando el elegido que la lleve equipada ataque inflige 1 de da�o a tu oponente", "Chronos", "Equipo", 0)); //TODO
        
        cardList.Add(new Card(63, "Rifle Bleck", 3, 0, 0, 0, "Aumenta en 1 el ataque, <sprite name=AlSerDestruido> destruye un elegido", "Chronos", "Equipo", 0)); //TODO
        
        cardList.Add(new Card(64, "El�ctroBola", 3, 0, 0, 0, "Solo puede ser equipada en elegidos bolt, duplica el ataque de estos cuando atacan a un elegido que no sea de Miknit", "Miknit", "Equipo", 0)); //TODO
        // Revoluci�n Steampunk 2 (Mec�nica Fant�stica y Artefactos Extaordianrios)
        // 

        // Revoluci�n Steampunk 3 (Revolucionarios)
        cardList.Add(new Card(65, "Sonya Delay", 10, 1, 10, 10, "Mientras esta carta este en el campo tu rival no puede atacar con sus elegidos", "Chronos", "", 0)); //TODO
        
        cardList.Add(new Card(66, "Edelgard", 10, 20, 10, 10, "Esta elegida puede atacar tantas veces a elegidos enemigos como quiera pero no puede atacar directamente", "Murgu", "", 0)); //TODO
        
        cardList.Add(new Card(67, "Ace Electro", 10, 4, 4, 10, "Mientras esta carta este en el campo tu rival no puede colocar trampas ni equipar cartas de equipo", "Miknit", "", 0)); //TODO

        cardList.Add(new Card(68, "Genex", 10, 10, 10, 20, "Cada vez que finalice tu turno recupera toda su vida", "Dana", "", 0, new List<ActivationType> { ActivationType.OnEndTurn }, new int[1] { 6 }, new int[1] { 1 }, new string[1] { "Genex" }, null, null, null, new int[1] { 20 }));
        
        cardList.Add(new Card(69, "Fazos", 10, 5, 5, 5, "Mientras esta carta este en el campo tu adversario no puede invocar de forma especial", "Yrys", "", 0)); //TODO

        cardList.Add(new Card(70, "Mona", 10, 10, 10, 10, "<sprite name=AlSerInvocado> destruye todos los elegidos que su dios no sean de Etse", "Etse", "", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] { 2 }, new int[1] { 100 }, null, null, new string[1] { "Etse" }, null, null));

        cardList.Add(new Card(71, "Deicidio", 10, 0, 0, 0, "Si todo tu mana es mana de los dioses transformalo en mana, aumenta permanentemente en 2 tu mana maximo, no puedes obtener mana de los dioses despu�s de activar este efecto", "N", "M�gica", 0)); //TODO

        cardList.Add(new Card(72, "Emperor Red", 6, 0, 0, 0, "Siempre que un elegido de chronos ataque el elegido del rival no puede contraatacar", "Chronos", "Dominio", 0)); //TODO

        cardList.Add(new Card(73, "Ba�o de sangre", 6, 0, 0, 0, "Cuando un elegido es destruido recupera toda la vida de tus elegidos de murgu", "Murgu", "Dominio", 0)); //TODO

        cardList.Add(new Card(74, "Electromagnetismo", 6, 0, 0, 0, "Al invocar un elegido de Miknit puede atacar sin esperar", "Miknit", "Dominio", 0)); //TODO

        cardList.Add(new Card(75, "Neblina p�rpura", 6, 0, 0, 0, "Los elegidos invocados que no sean de Dana pierden la mitad de su ataque y defensa", "Dana", "Dominio", 0)); //TODO

        cardList.Add(new Card(76, "Zona extra�a", 1, 0, 0, 0, "Cambia el ataque por la defensa de todos los elegidos invocados, si el elegido es de Yrys el invocador puede decir si cambiar o no el ataque", "Yrys", "Dominio", 0)); //TODO

        cardList.Add(new Card(77, "Cementerio de almas", 6, 0, 0, 0, "Cuando un elegido es destruido traelo de vuelta desde el cementerio, la pr�xima vez que fueran a ser destruidos destierralos", "Etse", "Dominio", 0)); //TODO
                                                                                                                                                                                                                             // Revoluci�n Steampunk 4 (Linea de defensa)
        cardList.Add(new Card(78, "Ruby VIII", 5, 2, 2, 5, "<sprite name=AlSerInvocado> roba una carta m�gica <sprite name=Deck>", "Miknit", "Hechicera", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] { 1 }, new int[1] { 1 }, new string[1] { "M�gica" }, null, null, null, new int[1] { 1 }));
        
        cardList.Add(new Card(79, "Eins", 5, 10, 1, 1, "  <sprite name=AlSerInvocado> de forma normal invoca  <sprite name=Deck> a Zwei y Drei", "Chronos", "Artificiero", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(80, "Zwei", 5, 10, 1, 1, "  <sprite name=AlSerInvocado> de forma normal invoca  <sprite name=Deck> a Eins y Drei", "Chronos", "Artificiero", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(81, "Drei", 5, 10, 1, 1, "  <sprite name=AlSerInvocado> de forma normal invoca  <sprite name=Deck> a Eins y Zwei", "Chronos", "Artificiero", 0, new List<ActivationType> { ActivationType.OnEnterField }));

        cardList.Add(new Card(82, "Atom", 5, 6, 5, 7, "<sprite name=AlSerInvocado> destruye una carta de tu adversario", "Dana", "Hechicera", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] { 2 }, new int[1] { 1 }));


        cardList.Add(new Card(83, "Vix", 5, 7, 3, 5, "  <sprite name=AlSerInvocado> equipala a un monstruo rival este pierde todo su ataque, cuando este es destruido devuelve esta carta a tu zona de elegidos", "Murgu", "Luchadora", 0)); //TODO

        // Revoluci�n Steampunk 5 (Nuevos Trabajos)
        cardList.Add(new Card(84, "Myu", 2, 1, 1, 1, "  <sprite name=AlSerInvocado> busca un elegido  <sprite name=Deck>  del rival, destierralo", "Chronos", "Tirador", 0, new List<ActivationType> { ActivationType.OnEnterField }));//TODO
        
        cardList.Add(new Card(85, "Drip", 2, 1, 1, 1, "  <sprite name=AlSerInvocado> busca una m�gica  <sprite name=Deck> del rival, destierrala", "Dana", "Mercader", 0, new List<ActivationType> { ActivationType.OnEnterField })); //TODO

        cardList.Add(new Card(86, "BeeBot", 2, 1, 1, 1, "<sprite name=AlSerInvocado> roba una m�gica <sprite name=Deck>", "N", "Robot", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] { 1 }, new int[1] { 1 }, new string[1] { "M�gica" }, null, null, null, new int[1] { 1 }));

        cardList.Add(new Card(87, "Emil", 2, 1, 1, 1, "<sprite name=AlSerInvocado> busca una trampa <sprite name=Deck> del rival, desti�rrala", "Dana", "Mercader", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] { 3 }, new int[1] { 1 }, new string[1] { "Trampa" }, null, null, null, new int[1] { 1 }));

        cardList.Add(new Card(88, "M.4.1.D", 2, 1, 1, 1, "<sprite name=AlSerInvocado> roba una carta de equipo <sprite name=Deck>", "N", "Robot", 0, new List<ActivationType> { ActivationType.OnEnterField }, new int[1] { 1 }, new int[1] { 1 }, new string[1] { "Equipo" }, null, null, null, new int[1] { 1 }));
        
        cardList.Add(new Card(89, "Kelith", 1, 1, 1, 1, "  <sprite name=AlSerInvocado> mira las 3 cartas de la parte superior  <sprite name=Deck> colocalas de vuelta en el orden que quieras", "Chronos", "Mercader", 0, new List<ActivationType> { ActivationType.OnEnterField }));//TODO
        
        cardList.Add(new Card(90, "Decay", 2, 1, 1, 1, "  <sprite name=AlSerInvocado> busca una carta de equipo  <sprite name=Deck> rival, destierrala", "Chronos", "Hechicero", 0, new List<ActivationType> { ActivationType.OnEnterField })); //TODO
        
        cardList.Add(new Card(91, "Efraim", 2, 1, 1, 1, "  <sprite name=AlSerInvocado> busca una carta de dominio  <sprite name=Deck> rival, destierrala", "Dana", "Artificiero", 0, new List<ActivationType> { ActivationType.OnEnterField })); //TODO


        // Miknit's Mana War Legacy 

        cardList.Add(new Card(92, "Myura", 10, 8, 4, 7, "  <sprite name=AlSerInvocado> limita la zonas de elegidosa 3, si tu oponente tiene la zona de elegidos al completo puedes invocar esta carta de la mano", "Miknit", "Hechicera", 0)); //TODO
        cardList.Add(new Card(93, "Etrian", 10, 8, 10, 8, "  <sprite name=AlSerInvocado> Invoca tantos elegidos  <sprite name=Deck> de coste 1 como mana de Miknit tengas, gasta todo el mana de Miknit", "Miknit", "Guerrero", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(94, "Klio", 10, 10, 8, 8, "  <sprite name=AlSerInvocado> Invoca todos los elegidos de tu mano, cuando vayan a ser enviados al cementerio destierralos", "Miknit", "Mercenario", 0, new List<ActivationType> { ActivationType.OnEnterField })); //TODO
        cardList.Add(new Card(95, "Elfraim", 1, 1, 1, 1, "  <sprite name=AlSerInvocado> copia el efecto de un elegido en el campo", "Miknit", "Explorador", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(96, "Fath", 4, 2, 5, 3, "No es afectado por efectos de otros elegidos, si un elegido que controles fuera a ser destruido puedes elegir destruir a este en su lugar", "Miknit", "Guerrero", 0)); //TODO
        cardList.Add(new Card(97, "Momo", 4, 2, 3, 5, "  <sprite name=AlSerInvocado> invoca  <sprite name=Deck> un elegido de coste 1", "Miknit", "Invocadora", 0, new List<ActivationType> { ActivationType.OnEnterField }));


        // Miknit's Mana War Legacy 2
        cardList.Add(new Card(98, "Lilyan", 4, 3, 3, 2, "Mientras esta carta esta en el campo ningun jugador puede usar cartas m�gicas, no es afectada por efectos de cartas", "Miknit", "Guerrera", 0)); //TODO
        cardList.Add(new Card(99, "Lancelot", 6, 6, 2, 3, "<sprite name=AlSerInvocado> puede atacar sin esperar", "Miknit", "Guerrero", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(100, "Axel", 6, 4, 1, 10, "Se cura 2hp cada vez que un elegido enemigo ataca", "Miknit", "Barbaro", 0)); //TODO
        cardList.Add(new Card(101, "Filo", 1, 3, 1, 2, "Puedes invocarla en el campo del rival roba dos cartas si haces esto", "Miknit", "P�cara", 0)); //TODO
        cardList.Add(new Card(102, "Leynla", 3, 4, 3, 6, "Cuando inicie tu fase de combate devuelve esta carta a la mano e invoca a Leynla Dragon", "Miknit", "Barbara", 0, new List<ActivationType> { ActivationType.OnStartBattle }));
        cardList.Add(new Card(103, "Leynla Drag�n", 6, 6, 8, 12, "No puede ser invocada de forma normal, cuando acabe la fase de combate vuelve a la mano e Invoca a Leynla", "Miknit", "Barbara", 0, new List<ActivationType> { ActivationType.OnEndBattle }));

        cardList.Add(new Card(104, "Kit", 2, 4, 1, 1, " <sprite name=AlSerInvocado> tira un d6 destruye tantas cartas en el campo igual al resultado, si no hay suficientes cartas en el campo destruye solo a este elegido", "Miknit", "Hechicero", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(105, "Ruby", 10, 6, 7, 5, " <sprite name=AlSerInvocado> recupera todo el mana de Miknit que hallas gastado este turno", "Miknit", "Guerrera", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(106, "Yuu", 4, 1, 3, 10, "Aumenta en 1 su ataque cada vez que recupera hp", "Miknit", "Mercenario", 0));
        cardList.Add(new Card(107, "Ryo", 4, 1, 4, 10, "Una vez por turno cura 1hp a un elegido", "Miknit", "Curandera", 0, new List<ActivationType> { ActivationType.OncePerTurn}));
        cardList.Add(new Card(108, "Henka", 6, 7, 2, 3, "<sprite name=AlSerInvocado> busca una carta de equipo  <sprite name=Deck> y robala, una vez por turno puedes cambiar una carta de equipo en el campo por otra <sprite name=Deck>", "Miknit", "P�cara", 0, new List<ActivationType> { ActivationType.OnEnterField, ActivationType.OncePerTurn }));
        cardList.Add(new Card(109, "Paladya", 10, 4, 8, 6, "No puede ser invocado si no tienes tu zona de elegidos llena, <sprite name=AlSerInvocado> destruye todos los elegidos, despu�s ambos jugadores descartan su mano", "Miknit", "Curandera", 0)); //TODO
        cardList.Add(new Card(110, "Grey", 3, 5, 3, 4, "Una vez por turno puedes inflirle 1 de da�o a un elegido", "Miknit", "Invocador", 0, new List<ActivationType> { ActivationType.OncePerTurn }));
        cardList.Add(new Card(111, "Mansel", 10, 8, 14, 12, "<sprite name=AlSerInvocado> tu oponente no puede robar cartas de su deck en su siguiente turno excepto el robo inicial", "Miknit", "Invocador", 0, new List<ActivationType> { ActivationType.OnEnterField }));

        cardList.Add(new Card(112, "Dathe", 1, 1, 1, 1, "<sprite name=AlSerInvocado> busca la carta <Muerte U.Recurso>", "Miknit", "Invocador", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(113, "Muerte U.Recurso", 1, 0, 0, 0, "Solo puedes usar esta carta si te quedan 10 cartas o menos en  <sprite name=Deck>,  destierra todo  <sprite name=Deck>  y cementerio, devuelve  <sprite name=Deck>  todos los elegidos, despu�s roba 2 cartas", "Etse", "M�gica", 0)); //TODO

        cardList.Add(new Card(114, "Keon", 3, 2, 10, 6, "Mientras esta carta este en posici�n de defensa los elegidos enemigos tienen que atacarla", "Miknit", "Guerrero", 0)); //TODO
        cardList.Add(new Card(115, "Socram", 10, 6, 1, 25, "Recupera toda su vida cuando un elegido aliado de Miknit es destruido", "Miknit", "Barbaro", 0)); //TODO
        cardList.Add(new Card(116, "Yro", 1, 3, 1, 1, "  <sprite name=AlSerInvocado> si tienes 2 o mas mana de Miknit destruye un elegido en el campo de tu adversario", "Miknit", "Hechicero", 0)); //TODO
        cardList.Add(new Card(117, "Lime", 5, 7, 6, 1, "Esta carta no puede ser destruida en batalla", "Miknit", "B�rbara", 0)); //TODO
        cardList.Add(new Card(118, "Yawaraki", 5, 6, 7, 1, "Esta carta no puede ser destruida en batalla", "Miknit", "B�rbaro", 0)); //TODO
        cardList.Add(new Card(119, "Aki", 2, 3, 1, 2, "  <sprite name=AlSerInvocado> invoca en el campo del rival Enredaderas 0/5/5 en defensa", "Miknit", "Exploradora", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(120, "Sai", 5, 7, 2, 3, "Puedes invocar esta carta en el campo del rival destruyendo uno de sus monstruos", "Miknit", "P�caro", 0)); //TODO
        cardList.Add(new Card(121, "Cadmy", 10, 3, 6, 5, "No puede ser invocado si tu zona de elegidos no esta vacia, <sprite name=AlSerInvocado> destruye todos los elegidos, despu�s ambos jugadores descartan su mano", "Miknit", "Curandera", 0)); //TODO
        cardList.Add(new Card(122, "Lorenz", 4, 3, 3, 6, "Una vez por turno puedes devolver esta carta al deck y robar una carta", "Miknit", "Invocador", 0, new List<ActivationType> { ActivationType.OncePerTurn })); //TODO

        cardList.Add(new Card(123, "Elif", 1, 1, 1, 1, "<sprite name=AlSerInvocado> busca la carta <Vida U.Recurso>", "Miknit", "Invocadora", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(124, "Vida U.Recurso", 0, 0, 0, 0, "Solo puedes usar esta carta si te quedan 10 cartas o menos en  <sprite name=Deck>,  envia al cementerio todo <sprite name=Deck>  y <sprite name=Mano>, devuelve  <sprite name=Deck>  todos los elegidos, despu�s roba 2 cartas", "Dana", "M�gica", 0)); //TODO
        // Sobre Colaboraciones Radiantes
        cardList.Add(new Card(125, "Matthew Bleck", 0, 0, 0, 2, "", "Chronos", "Explorador", 0)); //TODO
        cardList.Add(new Card(126, "Yu", 1, 1, 0, 2, "  <sprite name=AlSerInvocado> tira un dado, segun el resultado invoca: 1- Yu 0/0/2, 2 Oveja 1/1/2, 3 Zorro 3/1/2, 4 lobo 6/2/3, 5 caballo 6/6/6 ,6 drag�n 10/10/10", "N", "Invocador", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(127, "Togha", 4, 3, 2, 3, "Una vez por turno devuelve una carta m�gica del cementerio al  <sprite name=Deck>, roba una con un nombre distinto", "N", "Hechicero", 0, new List<ActivationType> { ActivationType.OncePerTurn }));
        cardList.Add(new Card(128, "Marinette", 3, 4, 4, 2, "Cada vez que destruye un elegido roba una carta", "N", "Robot", 0, new List<ActivationType> { ActivationType.OnDestroyCard }));
        cardList.Add(new Card(129, "Cristian Anim", 0, 0, 0, 2, "", "N", "Robot", 0)); //TODO
        cardList.Add(new Card(130, "Iker Video", 0, 0, 0, 2, "", "N", "Explorador", 0)); //TODO
        cardList.Add(new Card(131, "Iker Anim", 0, 0, 0, 2, "", "N", "Explorador", 0)); //TODO
        cardList.Add(new Card(132, "Alberto Video", 0, 0, 0, 2, "", "N", "Explorador", 0)); //TODO
        cardList.Add(new Card(133, "Alberto Anim", 0, 0, 0, 2, "", "N", "Explorador", 0)); //TODO
        cardList.Add(new Card(134, "Robinson", 0, 0, 0, 2, "", "N", "Explorador", 0)); //TODO
        cardList.Add(new Card(135, "Starship Odyssey", 5, 4, 12, 1, "Una vez por turno duplica su ataque", "N", "Robot", 0)); //TODO

        cardList.Add(new Card(136, "Dana", 12, 20, 20, 50, "No puede ser seleccionada por efectos de cartas, <sprite name=AlSerInvocado> invoca del cementerio tantos elegidos como quieras", "Dana", "Diosa", 0, new List<ActivationType> { ActivationType.OnEnterField })); //TODO
        cardList.Add(new Card(137, "Etse", 12, 50, 20, 20, "No puede ser seleccionada por efectos de cartas, <sprite name=AlSerInvocado> destruye tantos elegidos en el campo como quieras", "Etse", "Dios", 0, new List<ActivationType> { ActivationType.OnEnterField })); //TODO
        cardList.Add(new Card(138, "Miknit", 12, 30, 30, 30, "No puede ser seleccionada por efectos de cartas, <sprite name=AlSerInvocado> recupera todo tu mana como mana", "Miknit", "Diosa", 0, new List<ActivationType> { ActivationType.OnEnterField })); //TODO
        cardList.Add(new Card(139, "Chronos", 12, 25, 35, 30, "No puede ser seleccionada por efectos de cartas, <sprite name=AlSerInvocado> roba tantas cartas como quieras", "Chronos", "Dios", 0, new List<ActivationType> { ActivationType.OnEnterField })); //TODO
        cardList.Add(new Card(140, "Murgu", 12, 35, 35, 15, "No puede ser seleccionada por efectos de cartas, <sprite name=AlSerInvocado> triplica el ataque de todos tus elegidos", "Murgu", "Dios", 0, new List<ActivationType> { ActivationType.OnEnterField })); //TODO 
        cardList.Add(new Card(141, "Yrys", 12, 40, 30, 20, "No puede ser seleccionada por efectos de cartas, <sprite name=AlSerInvocado> destierra tantos elegidos en el campo como quieras", "Yrys", "Diosa", 0, new List<ActivationType> { ActivationType.OnEnterField })); //TODO


        // Sobre de Magia para novatos y no tan novatos
        cardList.Add(new Card(142, "Misil M�gico", 1, 0, 0, 0, "Inflije 1 de HP a un elegido", "Miknit", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(143, "Escarchar", 1, 0, 0, 0, "Reduce en 1 la DF de un elegido", "Miknit", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(144, "Refuerzos", 2, 0, 0, 0, "Roba un mercenario  <sprite name=Deck>, si su coste es 1 invocalo de forma especial", "Murgu", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(145, "Portal", 10, 0, 0, 0, "Invoca 3 Hechiceros  <sprite name=Deck>,mano o zona de destierros", "Miknit", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(146, "Toque de la Muerte", 3, 0, 0, 0, "Destruye un elegido en el campo, solo puedes activar esta carta si hay un Hechicero en tu zona de elegidos", "Etse", "M�gica", 0)); //TODO
        cardList.Add(new Card(147, "Fireball", 8, 0, 0, 0, "Destruye todos los monstruos en el campo", "Miknit", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(148, "Resucitar", 2, 0, 0, 0, "Devuelve un elegido del cementerio al  <sprite name=Deck>", "Dana", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(149, "Perdici�n", 7, 0, 0, 0, "Envia a la zona de destierros un elegido en el campo", "Yrys", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(150, "Hacer a�icos", 2, 0, 0, 0, "Inflije 1 de hp a un elegido, si tiene una carta de equipo destruyela", "Etse", "M�gica", 0)); //TODO
        cardList.Add(new Card(151, "Jarron Avaricioso", 2, 0, 0, 0, "Roba dos cartas", "N", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(152, "Jarron Generoso", 2, 0, 0, 0, "Descarta dos cartas", "N", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(153, "Agujero de Gusano", 10, 0, 0, 0, "Destierra todos los monstruos en el campo, despu�s ambos jugadores invocan tantos monstruos del cementerio como puedan", "Yrys", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField })); //TODO
        cardList.Add(new Card(154, "Lluvia de meteroros", 9, 0, 0, 0, "Destruye todos los monstruos de tu oponente", "Yrys", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(155, "Curar heridas", 1, 0, 0, 0, "Recupera 5LP", "Dana", "M�gica", 0, new List<ActivationType> { ActivationType.OnEnterField }));
        cardList.Add(new Card(156, "Sue�o", 3, 0, 0, 0, "Cuando un elegido ataque su ataque se vuelve 0", "Miknit", "Trampa", 0)); //TODO

        cardList.Add(new Card(157, "Armadura de Magia", 2, 0, 0, 0, "Aumenta en 2 la defensa de un hechicero", "Miknit", "Equipo", 0)); //TODO
        cardList.Add(new Card(158, "Arma de luz", 1, 0, 0, 0, "Aumenta en 2 el ataque de un curandero", "Miknit", "Equipo", 0)); //TODO


        cardList.Add(new Card(159, "Curar heridas graves", 5, 0, 0, 0, "Si tus LP disminuyen de 10 curate 20LP", "Dana", "Trampa", 0)); //TODO
        cardList.Add(new Card(160, "Ida y vuelta", 2, 0, 0, 0, "Despu�s de que uno de tus elegidos <sprite name=AlAtacar>, devuelvelo a la mano e invoca de esta un elegido con el mismo coste o menor", "Murgu", "Trampa", 0)); //TODO
        // Cartas Desbloqueables Mundo Antiguo
        cardList.Add(new Card(1000, "Blight", 10, 20, 20, 20, "Un rey olvidado por el mundo", "N", "Guerrero", 0));
        cardList.Add(new Card(1001, "N�0", 1, 1, 1, 1, "<sprite name=AlSerInvocado> destierra todas las cartas N� en el cementerio aumenta en 1 su vida por cada una", "Chronos", "Invocadora", 0, new List<ActivationType> { ActivationType.OnEnterField }));

        // Cartas Desbloqueables Revoluci�n Steampunk
        cardList.Add(new Card(1002, "HelAI", 6, 3, 14, 5, "Si este elegido es el �nico en tu campo es destruido, si un elegido tuyo tiene una carta de equipo puedes invocar a este de forma especial", "Chronos", "Robot", 0)); //TODO


        // Fichas
        cardList.Add(new Card(0, "Soldado de arena", 0, 0, 4, 1, "No puede ser destruido en batalla si N�11 esta en el campo", "N", "Invocaci�n", 0)); //TODO
        cardList.Add(new Card(0, "Chakal", 0, 5, 1, 2, "<sprite name=AlAtacar> cambia a posicion de defensa", "N", "Invocaci�n", 0, new List<ActivationType> { ActivationType.OnAttack }));
        cardList.Add(new Card(0, "Lia", 0, 9, 0, 1, "<sprite name=AlSerDestruido> en batalla envia del cementerio al  <sprite name=Deck>  la carta de equipo Lia", "none", "Invocaci�n", 0, new List<ActivationType> { ActivationType.OnLeaveField }));
        cardList.Add(new Card(0, "Enredaderas", 0, 0, 5, 5, "Al final del turno crea una copia de si misma, si no puede inflije 1LP al jugador que posea esta carta", "N", "Invocaci�n", 0, new List<ActivationType> { ActivationType.OnEndTurn }));
        cardList.Add(new Card(0, "Yu", 0, 0, 0, 2, "<sprite name=AlSerDestruido> omites tu proximo robo", "N", "Invocaci�n", 0, new List<ActivationType> { ActivationType.OnLeaveField }));
        cardList.Add(new Card(0, "Oveja", 0, 1, 1, 2, "<sprite name=AlSerDestruido> omites tu proximo robo", "N", "Invocaci�n", 0, new List<ActivationType> { ActivationType.OnLeaveField }));
        cardList.Add(new Card(0, "Zorro", 0, 3, 1, 2, "<sprite name=AlSerDestruido> omites tu proximo robo", "N", "Invocaci�n", 0, new List<ActivationType> { ActivationType.OnLeaveField }));
        cardList.Add(new Card(0, "Lobo", 0, 6, 2, 3, "<sprite name=AlSerDestruido> omites tu proximo robo", "N", "Invocaci�n", 0, new List<ActivationType> { ActivationType.OnLeaveField }));
        cardList.Add(new Card(0, "Caballo", 0, 6, 6, 6, "<sprite name=AlSerDestruido> omites tu proximo robo", "N", "Invocaci�n", 0, new List<ActivationType> { ActivationType.OnLeaveField }));
        cardList.Add(new Card(0, "Drag�n", 0, 10, 10, 10, "<sprite name=AlSerDestruido> omites tu proximo robo", "N", "Invocaci�n", 0, new List<ActivationType> { ActivationType.OnLeaveField }));

        // Limite

        
    }
}
