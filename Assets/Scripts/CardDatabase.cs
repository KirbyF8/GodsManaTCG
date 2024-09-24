using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
   public static List<Card> cardList = new List<Card>();

    private void Awake()
    {
        cardList.Add(new Card(0, "none", 0 , 0, 0, 0, "none", "none", "", 0));

        // Mundo Antiguo (Antes de los dioses)
        cardList.Add(new Card(1, "Yumi", 1, 2, 1, 4, "Una aventurera humana olvidada por el mundo", "N", "", 0));
        cardList.Add(new Card(2, "Lia", 1, 1, 2, 4, "Una aventurera elfa olvidadada por el mundo", "N", "", 0));
        cardList.Add(new Card(3, "Pipmos", 1, 3, 1, 2, "Un aventurero mediano olvidado por el mundo", "N", "", 0));
        cardList.Add(new Card(4, "Phaksa", 1, 2, 2, 3, "Una aventurera demi-humana olvidada por el mundo", "N", "", 0));
        cardList.Add(new Card(5, "Daro", 1, 1, 1, 6, "Un aventurero enano olvidado por el mundo", "N", "", 0));
        // Mundo Antiguo (Antes de los dioses (Desbloqueo))
        // cardList.Add(new Card(1000, "Blight", 10, 20, 20, 20, "Un rey olvidado por el mundo", "N", -1000, 0));
        // Mundo Antiguo 2 (N�)
        cardList.Add(new Card(6, "N�12 ", 1, 3, 0, 3, "Al ser destruida invoca de forma especial desde tu mano o deck a N�11", "N", "", 0));
        cardList.Add(new Card(7, "N�11", 2, 1, 4, 4, "Al ser invocada de forma especial crea 2 fichas [soldado de arena] 0/4/1, al ser destruida invoca de forma especial desde tu mano o deck a N�10 ", "none", "", 0));
        cardList.Add(new Card(8, "N�10", 3, 4, 1, 3, "Al ser invocada de forma especial roba 1 carta, al morir invoca de forma especial desde de tu mano o deck a N�9 ", "none", "", 0));
        cardList.Add(new Card(9, "N�9", 4, 8, 0, 1, "Al ser invocada de forma especial destruye 1 elegido del rival que este en posici�n de ataque, al morir invoca de forma especial desde tu mano o deck a N�8", "none", "", 0));
        cardList.Add(new Card(10, "N�8", 5, 6, 2, 4, "Al ser invocada de forma especial inflije 1 de da�o a todos los elegidos enemigos, al morir invoca de forma especial desde tu mano o deck a N�7", "none", "", 0));
        cardList.Add(new Card(11, "N�7", 6, 9, 1, 6, "Al ser invocada de forma especial destruye todos los elegidos heridos, al morir invoca de forma especial desde tu mano o deck a N�6", "none", "", 0));
        cardList.Add(new Card(12, "N�6", 7, 10, 1, 4, "Al ser invocada de forma especial inflije 5 de da�o a un elegido o a tu rival, al morir invoca de forma especial desde tu mano o deck a N�5", "none", "", 0));
        cardList.Add(new Card(13, "N�5", 8, 7, 5, 5, "Al ser invocada de forma especial reduce a 0 la defensa de todos los elegidos rivales, al morir invoca de forma especial desde tu mano o deck a N�4", "none", "", 0));
        cardList.Add(new Card(14, "N�4", 9, 5, 10, 10, "Al ser invocada de forma especial coloca a todos los elegidos en posici�n de defensa, al morir invoca de forma especial desde tu mano o deck a N�3", "none", "", 0));
        cardList.Add(new Card(15, "N�3", 10, 12, 6, 9, "Al ser invocada de forma especial destruye tantos elegidos hasta que quede uno en cada campo, al morir invoca de forma especial desde tu mano o deck a N�2", "none", "", 0));
        cardList.Add(new Card(16, "N�2", 11, 11, 10, 9, "Al ser invocada de forma especial busca una carta m�gica o trampa N� y a�adela a tu mano, al morir invoca de forma especial desde tu mano o deck a N�2", "none", "", 0));
        cardList.Add(new Card(17, "N�1", 12, 12, 12, 12, "Al ser invocada de forma especial gasta todo tu mana, esta carta no puede ser seleccionada por efectos, al final de cada ronda recupera toda su vida", "none", "Guerrera", 0));

        cardList.Add(new Card(18, "�ltimo esfuerzo N�", 0, 0, 0, 0, "Destruye un elegido N� despu�s destruye un elegido del rival, despu�s de activar el efecto no puedes invocar elegidos que no sean N� ", "M�gica", "", 0));
        cardList.Add(new Card(19, "Retirada N�", 0, 0, 0, 0, "Devuelve al Deck cualquier n�mero de N�, roba una carta por cada una", "M�gica", "", 0));
        cardList.Add(new Card(20, "Regrso N�", 0, 0, 0, 0, "Cuando una elegida N� es destruida, envia al deck 1 elegida N�", "Trampa", "", 0));
        cardList.Add(new Card(21, "Plan de contenci�n N�", 0, 0, 0, 0, "Cuando una elegida N� es destruida, envia al deck del cementerio 1 elegida N�", "Trampa", "", 0));
        // Mundo Antiguo 2 (N� (Desbloqueo))
        // cardList.Add(new Card(1001, "N�0", 1, 1, 1, 1, "Cuando esta carta es invocada destierra todas las cartas N� aumenta en 1 su vida por cada una", "N", -480, 0));

        // Mundo Antiguo 3 (Defensores del futuro)
        cardList.Add(new Card(22, "Lyriel", 2, 4, 2, 3, "Puede atacar directamente al rival", "N", "P�cara", 0));
        cardList.Add(new Card(23, "Sol", 3, 2, 1, 12, "Por cada punto de vida que le falte aumenta su ataque en 1", "none", "Luchador", 0));
        cardList.Add(new Card(24, "Zolbo", 1, 1, 1, 4, "Restaura la vida al completo de cualquier elegido", "none", "Curandero", 0));
        cardList.Add(new Card(25, "Emma", 2, 5, 2, 4, "Si esta en el campo tu rival no te puede atacar directamente", "none", "Mercenaria", 0));
        cardList.Add(new Card(26, "Leathen", 2, 1, 1, 1, "Al ser invocado toma el control de un elegido rival, al ser destruido devuelve el control del elegido a su propietario", "none", "Bardo", 0));
        cardList.Add(new Card(27, "Arwen", 2, 1, 3, 4, "Al ser invocada cura 2PV al jugador que la invoco", "Curandera", "", 0));
        
        

        // Mundo Antiguo 4 (Siervos N�)
        cardList.Add(new Card(28, "Klea", 1, 2, 2, 2, "Al ser invocada busca una N�1 en tu mazo", "N", "", 0));
        cardList.Add(new Card(29, "Kachal", 6, 2, 1, 5, "Al ser invocado invoca una ficha Chakal 5/1/2", "N", "", 0));
        cardList.Add(new Card(30, "Elcrieri", 9, 8, 2, 6, "Cada vez que ataque roba una carta", "N", "", 0));
        cardList.Add(new Card(31, "ShadowStep", 2, 4, 1, 1, "Al ser invocado coloca en posici�n de ataque un elegido en defensa", "N", "", 0));
        cardList.Add(new Card(32, "Dahila", 3, 4, 0, 4, "Si un elegido fuera a ser destruido puedes destruir esta en su lugar", "N", "", 0));
        cardList.Add(new Card(33, "Celine", 5, 4, 4, 6, "Cuando esta carta esta en el campo todos los elegidos que entren reciben 1 de da�o excetpo si esto los mata", "N", "", 0));
        cardList.Add(new Card(34, "Gumi", 4, 1, 4, 10, "Si el jugador rival recibe da�o aumenta el ataque de esta carta en esa cantidad hasta el final de ese turno", "N", "", 0));
        cardList.Add(new Card(35, "Amaro", 1, 5, 0, 1, "Al ser invocado destruye un elegido con 0 de defensa, si no puede esta carta es destruida", "N", "", 0));
        cardList.Add(new Card(36, "��igo", 2, 3, 2, 3, "Si un elejido pasa de defensa a ataque reduce el ataque de este a la mitad", "N", "", 0));
        cardList.Add(new Card(37, "Aul", 10, 10, 4, 10, "Si dos o mas elegidos son destruidos por el efecto de una carta puedes invocarla gratuitamente", "N", "", 0));
        cardList.Add(new Card(38, "Olivia", 8, 0, 10, 10, "Puedes destruir una carta m�gica o trampa, si lo haces tus elegidos que ya han atacado lo pueden volver a hacer", "N", "", 0));
        cardList.Add(new Card(39, "C�firo", 6, 6, 6, 6, "No puede ser destruido por efectos de elegidos", "N", "", 0));

        // Mundo Antiguo 5
        cardList.Add(new Card(40, "Rana Mercante", 1, 0, 0, 1, "Una vez por ronda puedes descartar 2 cartas para robar 1", "none", "Mercader", 0));
        
        cardList.Add(new Card(41, "Reglas antiguas", 0, 0, 0, 0, "Elimina todos los manas de los dioses", "M�gica", "", 0));
        cardList.Add(new Card(42, "�ltimo recurso", 0, 0, 0, 0, "Si tu vida es 1, obten 20 de mana", "M�gica", "", 0));
        cardList.Add(new Card(43, "Vuelta a lo b�sico", 0, 0, 0, 0, "Transforma todo el mana de los dioses a mana", "M�gica", "", 0));
        cardList.Add(new Card(44, "�ltimo esfuerzo", 0, 0, 0, 0, "Cuando un elegido vaya a ser destruido mantenlo a 1 de vida", "Trampa", ""   , 0));
        cardList.Add(new Card(45, "Castigo divino", 0, 0, 0, 0, "Destruye todos los monstruos en el campo", "M�gica", "", 0));


        // Revoluci�n Steampunk (La creacion de K.R.I.S)
        cardList.Add(new Card(46, "Orion Bolt", 1, 1, 1, 2, "A�ade K.R.I.S a tu mano", "Miknit", "Artificiero", 0));
        cardList.Add(new Card(47, "Martyn Bolt", 2, 1, 1, 1, "Al ser destruido en combate roba dos cartas", "Miknit", "Artificiero", 0));
        cardList.Add(new Card(48, "Ren Bolt", 5, 3, 2, 2, "Si K.R.I.S esta en el campo puedes invocar este elegido de forma especial desde el cementerio, al hacerlo aumenta el ataque de K.R.I.S en 1", "Miknit", "Artificiero", 0));
        cardList.Add(new Card(49, "Elen Bolt", 3, 6, 3, 3, "Si K.R.I.S es seleccionado como efecto puedes descartar esta carta y negar ese efecto", "Miknit", "Artificiera", 0));
        cardList.Add(new Card(50, "Leo Bolt", 4, 1, 4, 3, "Al ser invocado, si tienes a K.R.I.S en la mano, reduce su coste a la mitad", "Miknit", "Artificiero", 0));
        cardList.Add(new Card(51, "Nora Bolt", 6, 5, 2, 6, "Al ser invocada si Kris Bolt o K.R.I.S estan en el campo puedes buscar una carta que mencione a uno de los dos en tu deck y a�adirla a tu mano ", "Miknit", "Artificiera", 0));
        cardList.Add(new Card(51, "K.R.I.S", 10, 10, 10, 10, "Si esta en posici�n de defensa los elegidos enemigos solo pueden atacarle a el", "N", "Robot", 0));
        
        cardList.Add(new Card(52, "Electric field", 0, 0, 0, 0, "Aumenta el ataque de todos los elegidos Bolt y K.R.I.S en 1, si no hay al menos 1 Bolt en campo al finalizar el turno es destruida", "Campo", "", 0));
        cardList.Add(new Card(53, "Plan Bolt", 0, 0, 0, 0, "Si tienes 1 Bolt en el campo, 1 en el cementerio y 1 en la mano puedes invocar a K.R.I.S", "M�gica", "", 0));
        cardList.Add(new Card(54, "Eureka!", 0, 0, 0, 0, "Puedes equipar hasta 6 elegidos Bolt con nombres diferentes a K.R.I.S, este gana 1 de defensa y 2 de vida por cada uno", "M�gica", "", 0));
        // Revoluci�n Steampunk 2 (Mec�nica Fant�stica y Artefactos Extaordianrios)
        cardList.Add(new Card(55, "Kris Bolt", 5, 8, 1, 3, "Cuando es tu turno duplica su ataque, cuando es el turno del rival reducelo a la mitad", "Miknit", "Artificiero", 0));
        cardList.Add(new Card(56, "Valette Bleck", 4, 5, 2, 2, "Al ser invocada roba una carta de equipo, puedes destruir esta para destruir un elegido del rival", "Chronos", "Tiradora", 0));
        cardList.Add(new Card(57, "Nara", 3, 1, 2, 8, "Puede tener hasta 8 cartas equipadas", "Dana", "Mercenaria", 0));
        cardList.Add(new Card(58, "B.S.B-G.A.P-103", 8, 8, 16, 12, "Cada vez que destruye un elegido rival aumenta en 1 todas sus estad�sticas", "N", "Robot", 0));

        cardList.Add(new Card(59, "Bateria de Atem", 0, 0, 0, 0, "El elegido equipado con esto puede atacar dos veces por turno", "Equipo", "", 0));
        cardList.Add(new Card(60, "Lia", 0, 0, 0, 0, "Disminuye en 1 el ataque, cuando esta carta es destruida invoca en el campo del poseedor de la carta una ficha Lia 9/0/1", "Equipo", "", 0));
        cardList.Add(new Card(61, "Pistola Bleck", 0, 0, 0, 0, "Cuando el elegido que la lleve equipada ataque inflige 1 de da�o a tu oponente", "Equipo", "", 0));
        cardList.Add(new Card(62, "Rifle Keiser", 0, 0, 0, 0, "Aumenta en 1 el ataque, si esta carta es enviada al cementerio destruye un elegido", "Equipo", "", 0));
        cardList.Add(new Card(63, "El�ctroBola", 0, 0, 0, 0, "Solo puede ser equipada en elegidos bolt, duplica el ataque de estos cuando atacan a un elegido que no sea de Miknit", "Equipo", "", 0));
        // Revoluci�n Steampunk 2 (Mec�nica Fant�stica y Artefactos Extaordianrios)
        // cardList.Add(new Card(1002, "HelAI", 6, 3, 14, 5, "Si este elegido es el �nico en tu campo es destruido, si un elegido tuyo tiene una carta de equipo puedes invocar a este de forma especial", "Chronos", 0, 0));

        // Revoluci�n Steampunk 3 (Revolucionarios)
        cardList.Add(new Card(64, "Sonya Delay", 10, 1, 10, 10, "Mientras esta carta este en el campo tu rival no puede atacar con sus elegidos", "Chronos", "", 0));
        cardList.Add(new Card(65, "Edelgard", 10, 20, 10, 10, "Esta elegida puede atacar tantas veces a elegidos enemigos como quiera pero no puede atacar directamente", "Murgu", "", 0));
        cardList.Add(new Card(66, "Ace Electro", 10, 4, 4, 10, "Mientras esta carta este en el campo tu rival no puede colocar trampas ni equipar cartas de equipo", "Miknit", "", 0));
        cardList.Add(new Card(67, "Genex", 10, 10, 10, 20, "Cada vez que finalice tu turno recupera toda su vida", "Dana", "", 0));
        cardList.Add(new Card(68, "Fazos", 10, 5, 5, 5, "Mientras esta carta este en el campo tu adversario no puede invocar de forma especial", "Yrys", "", 0));
        cardList.Add(new Card(69, "Mona", 10, 10, 10, 10, "Cuando es invocada destruye todos los elegidos que su mana no sea de Etse", "Etse", "", 0));

        cardList.Add(new Card(70, "Deicidio", 10, 0, 0, 0, "Si todo tu mana es mana de los dioses transformalo en mana, aumenta permanentemente en 2 tu mana maximo, no puedes obtener mana de los dioses despu�s de activar este efecto", "none", "", 0));

        // Revoluci�n Steampunk 4 (Linea de defensa)
        cardList.Add(new Card(71, "Ruby VIII", 5, 2, 2, 5, "Cuando es invocada roba una carta m�gica a eleccion", "Miknit", "", 0));
        cardList.Add(new Card(72, "Eins", 5, 10, 1, 1, "Cuando es invocado de forma normal invoca desde el deck o mano a Zwei y Drei", "Chronos", "Artificiero", 0));
        cardList.Add(new Card(73, "Zwei", 5, 10, 1, 1, "Cuando es invocado de forma normal invoca desde el deck o mano a Eins y Drei", "Chronos", "Artificiero", 0));
        cardList.Add(new Card(74, "Drei", 5, 10, 1, 1, "Cuando es invocado de forma normal invoca desde el deck o mano a Eins y Zwei", "Chronos", "Artificiero", 0));

        cardList.Add(new Card(0, "none", 0, 0, 0, 0, "none", "none", "", 0));



        // Fichas
        cardList.Add(new Card(0, "Soldado de arena", 0, 0, 4, 1, "No puede ser destruido en batalla si N�11 esta en el campo", "N", "", 0));
        cardList.Add(new Card(0, "Chakal", 0, 5, 1, 2, "Al atacar cambia a posicion de defensa", "N", "", 0));
        cardList.Add(new Card(0, "Lia", 0, 9, 0, 1, "Cuando es destruida en batalla envia del cementerio al deck la carta de equipo Lia", "none", "", 0));
    }
}
