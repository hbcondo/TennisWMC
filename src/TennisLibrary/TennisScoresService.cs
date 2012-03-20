﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.IO;
using System.Text;

namespace TennisLibrary
{
    public class TennisScoresService
    {
        public List<Match> singles = new List<Match>();
        public List<Match> doubles = new List<Match>();

        internal string getScoresByWebRequest(ScoreTypes scoreType)
        {
            /*string sourceUrl = string.Format(
                Properties.Settings.Default.ScoresSource
                , (int)scoreType
                );*/

            string sourceUrl = "http://www.livexscores.com/xml/tall.txt";

            #region Response

            // 1315277338,1315277426,1315277338,20110906@54742*001/US Open - New York, USA - Hard - Arthur Ashe Stadium*Lopez Feliciano (ESP)*Murray Andy (GBR)*0*1315185425*2-2*00*00*1*6*4*6*2*6*0*0*0*0*20110905/01:00*6*0*usa.gif*OFF/OFF@54743*001/US Open - New York, USA - Hard - Arthur Ashe Stadium*Lisicki Sabine (GER)*Zvonareva Vera (RUS)*0*1315191581*2-2*00*00*2*6*3*6*0*0*0*0*0*0*20110905/03:30*6*0*usa.gif*OFF/OFF@54902*001/US Open - New York, USA - Hard - Arthur Ashe Stadium*Pavlyuchenkova Anastasia (RUS)*Schiavone Francesca (ITA)*0*1315245709*2-1*00*00*5*7*6*3*6*4*0*0*0*0*20110905/17:00*6*1315245922*usa.gif*OFF/OFF/1424629725@54903*001/US Open - New York, USA - Hard - Arthur Ashe Stadium*Williams Serena (USA)*Ivanovic  Ana (SRB)*0*1315251466*2-1*00*00*6*3*6*4*0*0*0*0*0*0*20110905/19:00*6*1315251762*usa.gif*OFF/OFF/1174502517@54904*001/US Open - New York, USA - Hard - Arthur Ashe Stadium*Tsonga Jo-Wilfried (FRA)*Fish Mardy (USA)*0*1315266165*2-1*00*00*6*4*6.5*7*3*6*6*4*6*2*20110905/20:30*6*1315266380*usa.gif*OFF/OFF/-1227374291@54905*001/US Open - New York, USA - Hard - Arthur Ashe Stadium*Wozniacki Caroline (DEN)*Kuznetsova Svetlana (RUS)*2*1315277338*2-1*00*00*6.6*7*7*5*0*0*0*0*0*0*20110906/01:00*3*1315277423*usa.gif*OFF/OFF@54906*001/US Open - New York, USA - Hard - Arthur Ashe Stadium*Federer Roger (SUI)*Monaco Juan (ARG)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110906/02:30*0*0*usa.gif*OFF/OFF@54907*002/US Open - New York, USA - Hard - Louis Armstrong Stadium*Tipsarevic Janko (SRB)*Ferrero Juan Carlos (ESP)*0*1315248889*2-1*00*00*7*5*6.3*7*7*5*6*2*0*0*20110905/17:00*6*1315249041*usa.gif*OFF/OFF/1998569929@54908*002/US Open - New York, USA - Hard - Louis Armstrong Stadium*Djokovic Novak (SRB)*Dolgopolov Alexandr (UKR)*0*1315258936*2-1*00*00*7*6.14*6*4*6*2*0*0*0*0*20110905/19:30*6*1315259087*usa.gif*OFF/OFF/-2124777165@54909*002/US Open - New York, USA - Hard - Louis Armstrong Stadium*Petkovic Andrea (GER)*Suarez Navarro Carla (ESP)*0*1315265319*2-1*00*00*6*1*6*4*0*0*0*0*0*0*20110905/22:00*6*1315265354*usa.gif*OFF/OFF@54750*003/US Open - New York, USA - Hard - Grandstand*Bopanna R./Qureshi A.-U.-H. (IND/PAK)*Hanley P./Norman D. (AUS/BEL)*0*1315182453*2-1*00*00*6*2*6*3*0*0*0*0*0*0*20110905/00:30*6*0*usa.gif*OFF/OFF@54910*003/US Open - New York, USA - Hard - Grandstand*Errani S./Vinci R. (ITA)*Dulko G./Pennetta F. (ARG/ITA)*0*1315248803*2-1*00*00*4*6*7*5*6*2*0*0*0*0*20110905/18:00*6*1315249041*usa.gif*OFF/OFF/397263936@54911*003/US Open - New York, USA - Hard - Grandstand*Devvarman S./Huey T. C. (IND/PHI)*Bhupathi M./Paes L. (IND)*0*1315255880*2-2*00*00*4*6*5*7*0*0*0*0*0*0*20110905/19:30*6*1315256161*usa.gif*OFF/OFF/-1831338970@54912*003/US Open - New York, USA - Hard - Grandstand*Dulko G./Schwank E. (ARG)*Gajdosova J./Soares B. (AUS/BRA)*0*1315261680*2-1*00*00*3*6*6*3*10*8*0*0*0*0*20110905/21:00*6*1315261983*usa.gif*OFF/OFF/1158631522@54913*003/US Open - New York, USA - Hard - Grandstand*Llodra M./Zimonjic N. (FRA/SRB)*Marrero D./Seppi A. (ESP/ITA)*0*1315267650*2-2*00*00*6.4*7*4*6*0*0*0*0*0*0*20110905/22:30*6*1315268868*usa.gif*OFF/OFF@54914*004/US Open - New York, USA - Hard - Court 17*King V./Shvedova Y. (USA/KAZ)*Pegula J./Townsend T. (USA)*0*1315240052*2-1*00*00*6*4*6*2*0*0*0*0*0*0*20110905/17:00*6*1315240096*usa.gif*OFF/OFF/672920538@54915*004/US Open - New York, USA - Hard - Court 17*Melzer J./Petzschner P. (AUT/GER)*Stakhovsky S./Youzhny M. (UKR/RUS)*0*1315245173*2-1*00*00*7*6.3*6*3*0*0*0*0*0*0*20110905/18:30*6*1315245467*usa.gif*OFF/OFF/1757710522@54916*004/US Open - New York, USA - Hard - Court 17*Fyrstenberg M./Matkowski M. (POL)*Delgado J./Marray J. (GBR)*0*1315254349*2-1*00*00*6.5*7*6*2*6*3*0*0*0*0*20110905/20:00*6*1315254649*usa.gif*OFF/OFF/1105970907@54917*004/US Open - New York, USA - Hard - Court 17*Peschke K./Srebotnik K. (CZE/SLO)*Hsieh S.-W./Voskoboeva G. (TPE/KAZ)*0*1315261020*2-1*00*00*6*3*6*1*0*0*0*0*0*0*20110905/21:30*6*1315261029*usa.gif*OFF/OFF/-1046587074@54918*004/US Open - New York, USA - Hard - Court 17*Govortsova O./Matkowski M. (BLR/POL)*Vesnina E./Paes L. (RUS/IND)*0*1315266077*2-2*00*00*2*6*4*6*0*0*0*0*0*0*20110905/23:00*6*1315266380*usa.gif*OFF/OFF@54919*005/US Open - New York, USA - Hard - Court 11*Hradecka L./Cermak F. (CZE)*Falconi I./Johnson S. (USA)*0*1315239809*2-1*00*00*7*5*7*5*0*0*0*0*0*0*20110905/17:00*6*1315240096*usa.gif*OFF/OFF/432367236@54920*005/US Open - New York, USA - Hard - Court 11*Hantuchova D./Radwanska A. (SVK/POL)*Kudryavtseva A./Makarova E. (RUS)*0*1315248741*2-1*00*00*6*3*4*6*6*2*0*0*0*0*20110905/18:30*6*1315249041*usa.gif*OFF/OFF/220473174@54921*005/US Open - New York, USA - Hard - Court 11*Martinez Sanchez M. J./Medina Garrigues A. (ESP)*Kirilenko M./Petrova N. (RUS)*0*1315255384*2-2*00*00*2*6*3*6*0*0*0*0*0*0*20110905/20:00*6*1315255678*usa.gif*OFF/OFF/-1510421897@54922*005/US Open - New York, USA - Hard - Court 11*Oudin M./Sock J. (USA)*Zahlavova Strycova B./Petzschner P. (CZE/GER)*0*1315260951*2-1*00*00*6*3*7*6.3*0*0*0*0*0*0*20110905/21:30*6*1315261029*usa.gif*OFF/OFF/-864792937@54847*020/ATP Challenger - Genova, Italy - Clay - Campo 1*Marti Yann (SUI)*Duran Guillermo (ARG)*0*1315221133*2-2*00*00*7*5*4*6*4*6*0*0*0*0*20110905/10:00*6*0*italy.gif*OFF/OFF/844878917@54848*020/ATP Challenger - Genova, Italy - Clay - Campo 1*Mager Gianluca (ITA)*Burzi Enrico (ITA)*0*1315223739*2-2*00*00*2*6*6*2*2*6*0*0*0*0*20110905/11:30*6*0*italy.gif*OFF/OFF@54849*020/ATP Challenger - Genova, Italy - Clay - Campo 1*Fabbiano Thomas (ITA)*Burzi Enrico (ITA)*0*1315237308*2-1*00*00*7*5*7*5*0*0*0*0*0*0*20110905/13:30*6*02:15:40*italy.gif*OFF/OFF/-445170759@54850*021/ATP Challenger - Genova, Italy - Clay - Campo 2*Linzer Michael (AUT)*Laaksonen Henri (SUI)*0*1315216090*2-1*00*00*6*3*6*3*0*0*0*0*0*0*20110905/10:00*6*0*italy.gif*OFF/OFF/-887558085@54851*021/ATP Challenger - Genova, Italy - Clay - Campo 2*Fabbiano Thomas (ITA)*Recouderc Laurent (FRA)*0*1315219087*2-1*00*00*6*4*6*1*0*0*0*0*0*0*20110905/11:30*6*0*italy.gif*OFF/OFF@54852*021/ATP Challenger - Genova, Italy - Clay - Campo 2*Balleret Benjamin (MON)*Olivo Renzo (ARG)*0*1315228012*2-1*00*00*2*6*7*6.6*6*0*0*0*0*0*20110905/13:00*6*0*italy.gif*OFF/OFF/1945202068@54853*030/ATP Challenger - Shanghai, China - Hard - Center Court*Gregorc Luka (SLO)*Rungkat Christopher (INA) - ret.*0*1315215200*2-1*00*00*6*3*2*1*0*0*0*0*0*0*20110905/06:00*6*0*china.gif*OFF/OFF/822831060@54854*030/ATP Challenger - Shanghai, China - Hard - Center Court*Hernych Jan (CZE)*Yani Michael (USA)*0*1315207948*2-1*00*00*4*6*6*2*6*2*0*0*0*0*20110905/07:30*6*0*china.gif*OFF/OFF/-1737969483@54855*030/ATP Challenger - Shanghai, China - Hard - Center Court*Wu Di (CHN)*Rieschick Sebastian (GER)*0*1315216615*2-1*00*00*6*3*6.6*7*6*2*0*0*0*0*20110905/09:00*6*0*china.gif*OFF/OFF/1387694051@54856*030/ATP Challenger - Shanghai, China - Hard - Center Court*De Voest R./Meffert D. (RSA/GER)*Wolmarans F./Yani M. (RSA/USA)*0*1315222312*2-2*0*0*6*4*3*6*7*10*0*0*0*0*20110905/10:30*6*0*china.gif*OFF/OFF/1526717125@54857*031/ATP Challenger - Shanghai, China - Hard - Court 5*Molchanov Denys (UKR)*Yoo Daniel (KOR)*0*1315224667*2-2*00*00*7*6.6*5*7*3*6*0*0*0*0*20110905/06:00*6*0*china.gif*OFF/OFF@54858*031/ATP Challenger - Shanghai, China - Hard - Court 5*Ito Tatsuma (JPN)*Baker Jamie (GBR)*0*1315224546*2-1*00*00*7*6.6*7*6.0*0*0*0*0*0*0*20110905/07:30*6*0*china.gif*OFF/OFF@54859*031/ATP Challenger - Shanghai, China - Hard - Court 5*Yang Tsung-Hua (TPE)*Soeda Go (JPN)*0*1315224523*2-1*00*00*7*6.8*6*3*0*0*0*0*0*0*20110905/09:00*6*0*china.gif*OFF/OFF@54860*032/ATP Challenger - Shanghai, China - Hard - Court 6*Duclos Pierre-Ludovic (CAN)*Kondo Hiroki (JPN)*0*1315224686*2-1*00*00*6*0*1*6*6*4*0*0*0*0*20110905/06:00*6*0*china.gif*OFF/OFF@54861*032/ATP Challenger - Shanghai, China - Hard - Court 6*Lim Yong-Kyu (KOR)*Ward James (GBR)*0*1315224486*2-2*00*00*6*3*3*6*4*6*0*0*0*0*20110905/07:30*6*0*china.gif*OFF/OFF@54862*032/ATP Challenger - Shanghai, China - Hard - Court 6*Chvojka E./Statham J. (CAN/NZL)*Ratiwatana S./Ratiwatana S. (THA)*0*1315224595*2-2*00*00*4*6*5*7*0*0*0*0*0*0*20110905/09:00*6*0*china.gif*OFF/OFF@54863*033/ATP Challenger - Shanghai, China - Hard - Court 7*Moriya Hiroki (JPN)*Wang Jimmy (TPE)*0*1315224707*2-1*00*00*7*6.4*7*5*0*0*0*0*0*0*20110905/06:00*6*0*china.gif*OFF/OFF@54864*033/ATP Challenger - Shanghai, China - Hard - Court 7*Chen Ti (TPE)*Zopp Jurgen (EST)*0*1315224464*2-2*00*00*6.4*7*6*0*3*6*0*0*0*0*20110905/07:30*6*0*china.gif*OFF/OFF@54865*033/ATP Challenger - Shanghai, China - Hard - Court 7*Dustov F./Ghedin R. (UZB/ITA)*Fruttero J. P./Klaasen R. (USA/RSA)*0*1315224581*2-2*00*00*3*6*4*6*0*0*0*0*0*0*20110905/09:00*6*0*china.gif*OFF/OFF@54867*040/ATP Challenger - Alphen aan den Rijn, Netherlands - Clay- Center*Van Der Linden Lennert (NED)*Berta Daniel (SWE)*0*1315233291*2-1*00*00*6*3*2*6*6*3*0*0*0*0*20110905/12:30*6*0*netherlands.gif*OFF/OFF@54869*041/ATP Challenger - Alphen aan den Rijn, Netherlands - Clay- Court 6*Folie Alexandre (BEL)*Michalicka Marek (CZE)*0*1315238005*2-1*00*00*6*4*6.1*7*6*4*0*0*0*0*20110905/12:30*6*0*netherlands.gif*OFF/OFF/-705554324@54870*042/ATP Challenger - Alphen aan den Rijn, Netherlands - Clay- Court 4*Vogeli Roman (CZE)*Mannapov Alexander (GER)*0*1315232008*2-1*00*00*6*3*6*2*0*0*0*0*0*0*20110905/12:30*6*0*netherlands.gif*OFF/OFF@54868*043/ATP Challenger - Alphen aan den Rijn, Netherlands - Clay- Court 10*McGee James (IRL)*Lukacs Denes (HUN)*0*1315233198*2-1*00*00*6*2*6*2*0*0*0*0*0*0*20110905/14:00*6*0*netherlands.gif*OFF/OFF/453754020@54871*050/ATP Challenger - Seville, Spain - Clay - Center Court*Nedelko Ivan (RUS)*Martin-Adalia Pablo (ESP) - wo.*0*1315248050*2-2*00*00*0*0*0*0*0*0*0*0*0*0*20110905/11:00*6*0*spain.gif*OFF/OFF@54872*050/ATP Challenger - Seville, Spain - Clay - Center Court*Ramirez Hidalgo Ruben (ESP)*Carballes Baena Roberto (ESP)*0*1315225778*2-1*00*00*6*3*6*2*0*0*0*0*0*0*20110905/13:00*6*0*spain.gif*OFF/OFF/-1818862646@54873*050/ATP Challenger - Seville, Spain - Clay - Center Court*Romboli Fernando (BRA)*Munoz-De La Nava Daniel (ESP)*0*1315233014*2-2*00*00*2*6*5*7*0*0*0*0*0*0*20110905/14:30*6*0*spain.gif*OFF/OFF/847910939@54874*050/ATP Challenger - Seville, Spain - Clay - Center Court*Cervantes-Huegun Inigo (ESP)*Ciric Nikola (SRB)*0*1315246716*2-2*00*00*7*6.8*3*6*6.5*7*0*0*0*0*20110905/17:45*6*1315246719*spain.gif*OFF/OFF/-1645872440@54875*051/ATP Challenger - Seville, Spain - Clay - Court 2*Schwartzman Diego Sebastian (ARG)*Schmid Michal (CZE)*0*1315248032*2-2*00*00*4*6*4*6*0*0*0*0*0*0*20110905/11:00*6*0*spain.gif*OFF/OFF@54876*051/ATP Challenger - Seville, Spain - Clay - Court 2*Arias-Blasco A./Osete-Montoro J. (ESP)*Granollers G./Menendez-Maceiras A. (ESP)*0*1315247865*2-2*00*00*1*6*1*6*0*0*0*0*0*0*20110905/12:30*6*0*spain.gif*OFF/OFF@54877*051/ATP Challenger - Seville, Spain - Clay - Court 2*Ramos A./Vagnozzi S. (ESP/ITA)*Calderon Cabello E./Carmona-Rodriguez J. (ESP)*0*1315247846*2-1*00*00*6*0*6*0*0*0*0*0*0*0*20110905/14:00*6*0*spain.gif*OFF/OFF@54878*052/ATP Challenger - Seville, Spain - Clay - Court 3*Olaso Guillermo (ESP)*Gomez-Herrera Carlos (ESP)*0*1315217563*2-1*00*00*6*3*6*1*0*0*0*0*0*0*20110905/11:00*6*0*spain.gif*OFF/OFF/-1372578087@54879*052/ATP Challenger - Seville, Spain - Clay - Court 3*Di Ienno Damiano (ITA)*Sousa Pedro (POR)*0*1315221777*2-2*00*00*1*6*1*6*0*0*0*0*0*0*20110905/12:30*6*0*spain.gif*OFF/OFF/-1608819210@54880*052/ATP Challenger - Seville, Spain - Clay - Court 3*Lizariturry J./Martin-Adalia P. (ESP)*Gimeno-Traver D./Navarro I. (ESP)*0*1315230712*2-2*00*00*3*6*6.4*7*0*0*0*0*0*0*20110905/14:00*6*0*spain.gif*OFF/OFF/725352742@54881*052/ATP Challenger - Seville, Spain - Clay - Court 3*Aguilar J./Roshan N. (CHI/AUS)*Carballes Baena R./Ojeda Lara R. (ESP)*0*1315238288*2-1*00*00*7*6.2*6*4*0*0*0*0*0*0*20110905/15:30*6*1315238317*spain.gif*OFF/OFF/-1611849459@54882*060/ATP Challenger - St. Remy, France - Hard - Central*Descloix Dorian (FRA)*Rousset Elie (FRA)*0*1315214140*2-2*00*00*4*6*6.6*7*0*0*0*0*0*0*20110905/09:00*6*0*france.gif*OFF/OFF/2105403220@54883*060/ATP Challenger - St. Remy, France - Hard - Central*Rakotondramanga Antso (MAD)*Mathieu Romain (FRA)*0*1315219134*2-2*00*00*3*6*5*7*0*0*0*0*0*0*20110905/10:30*6*0*france.gif*OFF/OFF/-2089944976@54884*060/ATP Challenger - St. Remy, France - Hard - Central*Florido Johan (FRA)*Dupuy Baptiste (FRA)*0*1315223346*2-2*00*00*2*6*0*6*0*0*0*0*0*0*20110905/12:00*6*0*france.gif*OFF/OFF/828366911@54885*060/ATP Challenger - St. Remy, France - Hard - Central*DHoir Vincent (FRA)*Reinwein Sami (GER)*0*1315228701*2-2*00*00*3*6*4*6*0*0*0*0*0*0*20110905/13:30*6*0*france.gif*OFF/OFF/-104315650@54886*060/ATP Challenger - St. Remy, France - Hard - Central*Escoffier Antoine (FRA)*Scaccianoce Florent (FRA)*0*1315234073*2-1*00*00*7*6*6*2*0*0*0*0*0*0*20110905/15:00*6*0*france.gif*OFF/OFF/1356075935@54923*060/ATP Challenger - St. Remy, France - Hard - Central*Coco Rudy (FRA)*Duche Thomas (FRA)*0*1315249158*2-1*00*00*6*1*6*4*0*0*0*0*0*0*20110905/16:30*6*0*france.gif*OFF/OFF@54924*060/ATP Challenger - St. Remy, France - Hard - Central*Vaisse Martin (FRA)*Rousset Elie (FRA)*0*1315249170*2-2*00*00*3*6*1*6*0*0*0*0*0*0*20110905/18:00*6*0*france.gif*OFF/OFF@54925*060/ATP Challenger - St. Remy, France - Hard - Central*Rice David (FRA)*Mathieu Romain (FRA)*0*1315249181*2-1*00*00*6*3*6*4*0*0*0*0*0*0*20110905/19:30*6*0*france.gif*OFF/OFF@54887*061/ATP Challenger - St. Remy, France - Hard - Court 2*Vaisse Martin (FRA)*Couronne David (FRA)*0*1315248785*2-1*00*00*6*3*6*2*0*0*0*0*0*0*20110905/09:00*6*0*france.gif*OFF/OFF@54888*061/ATP Challenger - St. Remy, France - Hard - Court 2*Rice David (FRA)*Costes Stephane (FRA)*0*1315248799*2-1*00*00*6*2*6*2*0*0*0*0*0*0*20110905/10:30*6*0*france.gif*OFF/OFF@54889*061/ATP Challenger - St. Remy, France - Hard - Court 2*Desein Niels (BEL)*Kontinen Micke (FIN)*0*1315248812*2-2*00*00*0*6*4*6*0*0*0*0*0*0*20110905/12:00*6*0*france.gif*OFF/OFF@54890*061/ATP Challenger - St. Remy, France - Hard - Court 2*Bossel Adrien (SUI)*Boumlil Kevin (FRA)*0*1315248828*2-1*00*00*6*1*6*2*0*0*0*0*0*0*20110905/13:30*6*0*france.gif*OFF/OFF@54891*061/ATP Challenger - St. Remy, France - Hard - Court 2*Tchoutakian Maxime (FRA)*Thornley Sean (GBR)*0*1315248841*2-2*00*00*3*6*1*6*0*0*0*0*0*0*20110905/15:00*6*0*france.gif*OFF/OFF@54926*061/ATP Challenger - St. Remy, France - Hard - Court 2*Maury Florent (FRA)*Dupuy Baptiste (FRA)*0*1315249191*2-2*00*00*1*6*4*6*0*0*0*0*0*0*20110905/16:30*6*0*france.gif*OFF/OFF@54927*061/ATP Challenger - St. Remy, France - Hard - Court 2*Kontinen Micke (FIN)*Agazzi Andrea (ITA)*0*1315249209*2-1*00*00*4*6*6*4*6*4*0*0*0*0*20110905/18:00*6*0*france.gif*OFF/OFF@54928*061/ATP Challenger - St. Remy, France - Hard - Court 2*Buchner Alexandre (FRA)*Reinwein Sami (GER)*0*1315249218*2-2*00*00*2*6*2*6*0*0*0*0*0*0*20110905/19:30*6*0*france.gif*OFF/OFF@54892*062/ATP Challenger - St. Remy, France - Hard - Court 1*Turco Vincent (FRA)*Duche Thomas (FRA)*0*1315248856*2-2*00*00*1*6*2*6*0*0*0*0*0*0*20110905/09:00*6*0*france.gif*OFF/OFF@54893*062/ATP Challenger - St. Remy, France - Hard - Court 1*Gallinaro Hugo (FRA)*Maury Florent (FRA)*0*1315248876*2-2*00*00*1*6*2*6*0*0*0*0*0*0*20110905/10:30*6*0*france.gif*OFF/OFF@54894*062/ATP Challenger - St. Remy, France - Hard - Court 1*Vernet Jean-Pascal (FRA)*Agazzi Andrea (ITA)*0*1315248896*2-2*00*00*1*6*6*3*0*6*0*0*0*0*20110905/12:00*6*0*france.gif*OFF/OFF@54895*062/ATP Challenger - St. Remy, France - Hard - Court 1*Laurent Mickael (FRA)*Buchner Alexandre (FRA)*0*1315248914*2-2*00*00*4*6*6*4*0*6*0*0*0*0*20110905/13:30*6*0*france.gif*OFF/OFF@54896*062/ATP Challenger - St. Remy, France - Hard - Court 1*Machizaud Enzo (FRA)*Perrot Benoit (FRA)*0*1315248934*2-2*00*00*1*6*4*6*0*0*0*0*0*0*20110905/15:00*6*0*france.gif*OFF/OFF@54929*062/ATP Challenger - St. Remy, France - Hard - Court 1*Bossel Adrien (SUI)*Perrot Benoit (FRA)*0*1315249230*2-1*00*00*6*4*6*2*0*0*0*0*0*0*20110905/16:30*6*0*france.gif*OFF/OFF@54930*062/ATP Challenger - St. Remy, France - Hard - Court 1*Escoffier Antoine (FRA)*Thornley Sean (GBR)*0*1315249241*2-1*00*00*6*4*6*3*0*0*0*0*0*0*20110905/18:00*6*0*france.gif*OFF/OFF@54897*070/ATP Challenger - Brasov, Romania - Clay - Central Court*Konecny Michal (CZE)*Gavrila Llaurentiu-Ady (ROU)*0*1315241359*2-1*00*00*6*3*6*0*0*0*0*0*0*0*20110905/12:30*6*0*romania.gif*OFF/OFF@54898*070/ATP Challenger - Brasov, Romania - Clay - Central Court*Luncanu Petru-Alexandru (ROU)*Mlendea Andrei (ROU)*0*1315241374*2-2*00*00*4*6*3*6*0*0*0*0*0*0*20110905/14:00*6*0*romania.gif*OFF/OFF@54899*070/ATP Challenger - Brasov, Romania - Clay - Central Court*Gard Catalin (ROU)*Becker Richard (GER)*0*1315241429*2-1*00*00*4*6*6*3*6*2*0*0*0*0*20110905/15:30*6*0*romania.gif*OFF/OFF@54900*071/ATP Challenger - Brasov, Romania - Clay - Court 3*Phillips Morgan (GBR)*Cruciat Adrian (ROU)*0*1315241449*2-1*00*00*7*6.7*1*6*6*3*0*0*0*0*20110905/12:30*6*0*romania.gif*OFF/OFF@54901*071/ATP Challenger - Brasov, Romania - Clay - Court 3*Konecny Michal (CZE)*Craciun Teodor-Dacian (ROU)*0*1315241412*2-1*00*00*6*3*6.3*7*6*1*0*0*0*0*20110905/15:30*6*0*romania.gif*OFF/OFF

            #endregion

            // prepare the web page we will be asking for
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sourceUrl);

            // MUST SPECIFY USER AGENT OR RESPONSE WILL BE BLANK!
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.4) Gecko/20070515 Firefox/3.0.0.4";

            // execute the request
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // we will read data via the response stream
            Stream resStream = response.GetResponseStream();
            string resString = string.Empty;

            using (BufferedStream buffer = new BufferedStream(resStream)) 
            { 
                using (StreamReader reader = new StreamReader(buffer)) 
                {
                    resString = reader.ReadToEnd(); 
                } 
            }

            return resString;
        }

        /// <summary>
        /// If no score type retrieval is specified, just default to finished match scores
        /// </summary>
        /// <returns></returns>
        public TennisScoresCollection GetTennisScores()
        {
            return GetTennisScores(ScoreTypes.FINISHED);
        }

        public TennisScoresCollection GetTennisScores(ScoreTypes scoreType)
        {
            string scores = getScoresByWebRequest(scoreType);
            //string scores = "1268368634,1268368671,1268368634,20100312@29791*004/ATP,WTA - Indian Wells, USA - Hard - Stadium 1*Sprem Karolina*Perry Shenay   *0*1268341589*2-1*00*00*6*2*4*6*6*3*0*0*0*0*20100311/20:00*6*01:52:25@29792*004/ATP,WTA - Indian Wells, USA - Hard - Stadium 1*Moya Carlos*Smyczek Tim*0*1268351110*2-1*00*00*7*6*7*6*0*0*0*0*0*0*20100311/21:30*6*02:20:19@29793*004/ATP,WTA - Indian Wells, USA - Hard - Stadium 1*Vinci Roberta*Oudin Melanie*0*1268358271*2-1*00*00*3*6*6*3*6*0*0*0*0*0*20100311/23:00*6*01:44:31@29794*004/ATP,WTA - Indian Wells, USA - Hard - Stadium 1*Berrer Michael*Fish Mardy*0*1268365415*2-2*00*00*6*1*1*6*3*6*0*0*0*0*20100312/00:30*6*01:35:22@29797*005/ATP,WTA - Indian Wells, USA - Hard - Stadium 2*Starace Potito - ret.*Chardy Jeremy*0*1268338924*2-2*00*00*1*6*1*4*0*0*0*0*0*0*20100311/20:00*6*01:04:13@29798*005/ATP,WTA - Indian Wells, USA - Hard - Stadium 2*Hradecka Lucie*Stephens Sloane*0*1268346945*2-2*00*00*6*7*6*7*0*0*0*0*0*0*20100311/21:30*6*01:53:20@29799*005/ATP,WTA - Indian Wells, USA - Hard - Stadium 2*Reynolds Bobby*Ancic Mario*0*1268354928*2-2*00*00*6*4*3*6*4*6*0*0*0*0*20100311/23:00*6*01:54:45@29800*005/ATP,WTA - Indian Wells, USA - Hard - Stadium 2*Safarova L./Zvonareva V.*Garbin T./Jankovic J.*0*1268361208*2-2*00*00*6*7*3*6*0*0*0*0*0*0*20100312/00:30*6*01:27:24@29803*006/ATP,WTA - Indian Wells, USA - Hard - Stadium 3*Safarova Lucie*Goerges Julia*0*1268342289*2-2*00*00*5*7*6*3*3*6*0*0*0*0*20100311/20:00*6*02:06:23@29804*006/ATP,WTA - Indian Wells, USA - Hard - Stadium 3*Cuevas Pablo*Gil Frederico*0*1268348449*2-1*00*00*6*4*7*5*0*0*0*0*0*0*20100311/21:30*6*01:24:59@29805*006/ATP,WTA - Indian Wells, USA - Hard - Stadium 3*Borwell S./Kops-Jones R.*Medina Garrigues A./Wozniacki C.*0*1268356304*2-1*00*00*7*6*4*6*1*0*0*0*0*0*20100311/23:00*6*01:49:50@29806*006/ATP,WTA - Indian Wells, USA - Hard - Stadium 3*Ram Rajeev*Koellerer Daniel*0*1268360043*2-2*00*00*1*6*3*6*0*0*0*0*0*0*20100312/00:30*6*00:48:40@29808*007/ATP,WTA - Indian Wells, USA - Hard - Court 4*Rochus Olivier*Fognini Fabio*0*1268342856*2-2*00*00*4*6*6*1*5*7*0*0*0*0*20100311/20:00*6*02:10:58@29809*007/ATP,WTA - Indian Wells, USA - Hard - Court 4*Raymond L./Stubbs R.*Kirilenko M./Radwanska A.*0*1268349339*2-2*00*00*4*6*6*4*0*1*0*0*0*0*20100311/21:30*6*01:30:26@29810*007/ATP,WTA - Indian Wells, USA - Hard - Court 4*Mayer Leonardo*Dabul Brian*0*1268356053*2-2*00*00*6*7*2*6*0*0*0*0*0*0*20100311/23:00*6*01:35:23@29811*007/ATP,WTA - Indian Wells, USA - Hard - Court 4*Dekmeijere L./Schnyder P.*Llagostera Vives N./Martinez Sanchez M. J.*0*1268361072*2-2*00*00*2*6*4*6*0*0*0*0*0*0*20100312/00:30*6*01:05:05@29812*007/ATP,WTA - Indian Wells, USA - Hard - Court 4*Brianti Alberta*Kvitova Petra*0*1268366149*2-2*00*00*3*6*4*6*0*0*0*0*0*0*20100312/02:00*6*01:10:11@29813*008/ATP,WTA - Indian Wells, USA - Hard - Court 5*Coin Julie*Paszek Tamira*0*1268340859*2-1*00*00*6*4*6*3*0*0*0*0*0*0*20100311/20:00*6*01:38:32@29814*008/ATP,WTA - Indian Wells, USA - Hard - Court 5*Dulko G./Pennetta F.*Uhlirova V./Voracova R.*0*1268346778*2-1*00*00*1*6*6*4*1*0*0*0*0*0*20100311/21:30*6*01:17:58@29815*008/ATP,WTA - Indian Wells, USA - Hard - Court 5*Rochus Christophe*Petzschner Philipp*0*1268352794*2-2*00*00*2*6*5*7*0*0*0*0*0*0*20100311/23:00*6*01:23:09@29816*008/ATP,WTA - Indian Wells, USA - Hard - Court 5*Coin J./Pelletier M.-E.*Petrova N./Stosur S.*0*1268357492*2-2*00*00*4*6*2*6*0*0*0*0*0*0*20100312/00:30*6*01:01:30@29817*008/ATP,WTA - Indian Wells, USA - Hard - Court 5*Chan Yung-Jan*Voegele Stefanie*0*1268362741*2-1*00*00*6*0*7*5*0*0*0*0*0*0*20100312/02:00*6*01:10:17@29818*009/ATP,WTA - Indian Wells, USA - Hard - Court 6*Falla Alejandro*Serra Florent*0*1268338138*2-2*00*00*1*6*2*6*0*0*0*0*0*0*20100311/20:00*6*00:53:08@29819*009/ATP,WTA - Indian Wells, USA - Hard - Court 6*Dulgheru Alexandra*Larcher De Brito Michelle*0*1268343998*2-1*00*00*6*2*6*2*0*0*0*0*0*0*20100311/21:30*6*01:17:11@29820*009/ATP,WTA - Indian Wells, USA - Hard - Court 6*Delgado Ramon*Beck Andreas*0*1268352535*2-1*00*00*6*7*6*2*6*4*0*0*0*0*20100311/23:00*6*02:04:48@29821*009/ATP,WTA - Indian Wells, USA - Hard - Court 6*Martic Petra*Tomljanovic Ajla*0*1268359143*2-1*00*00*7*6*6*1*0*0*0*0*0*0*20100312/00:30*6*01:31:24@29822*009/ATP,WTA - Indian Wells, USA - Hard - Court 6*Alves Thiago*Schuettler Rainer*0*1268364887*2-2*00*00*5*7*0*6*0*0*0*0*0*0*20100312/02:00*6*01:16:05@29823*010/ATP,WTA - Indian Wells, USA - Hard - Court 7*Garcia-Lopez Guillermo*Lacko Lukas*0*1268343790*2-1*00*00*4*6*6*4*7*5*0*0*0*0*20100311/20:00*6*02:24:22@29824*010/ATP,WTA - Indian Wells, USA - Hard - Court 7*Pironkova Tsvetana*Amanmuradova Akgul*0*1268348999*2-1*00*00*6*3*6*2*0*0*0*0*0*0*20100311/21:30*6*01:11:10@29825*010/ATP,WTA - Indian Wells, USA - Hard - Court 7*Phau Bjorn*Anderson Kevin*0*1268354577*2-2*00*00*3*6*3*6*0*0*0*0*0*0*20100311/23:00*6*01:13:02@29827*011/ATP,WTA - Indian Wells, USA - Hard - Court 8*Sevastova Anastasija*Llagostera Vives Nuria*0*1268341204*2-1*00*00*6*2*3*6*6*1*0*0*0*0*20100311/20:00*6*01:43:49@29828*011/ATP,WTA - Indian Wells, USA - Hard - Court 8*Zahlavova Strycova Barbora*Petkovic Andrea*0*1268348613*2-1*00*00*6*3*6*3*0*0*0*0*0*0*20100311/21:30*6*01:45:22@29829*011/ATP,WTA - Indian Wells, USA - Hard - Court 8*Kutuzova Viktoriya*Errani Sara*0*1268355208*2-2*00*00*5*7*2*6*0*0*0*0*0*0*20100311/23:00*6*01:33:10@29842*012/ATP Challenger - Rabat, Morocco - Clay - Central*Andujar P./Navarro I.*Fattar A./Idmbarek Y.*0*1268328158*2-1*00*00*6*1*6*1*0*0*0*0*0*0*20100311/17:30*6*00:43:52@29843*012/ATP Challenger - Rabat, Morocco - Clay - Central*Marrero D./Munoz-De La Nava D.*Bozoljac I./Bracciali D.*0*1268334149*2-2*00*00*3*6*6*7*0*0*0*0*0*0*20100311/18:30*6*01:28:43@29844*013/ATP Challenger - Rabat, Morocco - Clay - Court 1*Kavcic B./Meffert D.*Dolgopolov Jr. O./Sitak D.*0*1268333813*2-2*00*00*6*2*3*6*6*10*0*0*0*0*20100311/18:45*6*01:10:40@29845*014/ATP Challenger - Rabat, Morocco - Clay - Court 4*Chaki R./El Amrani R.*Cerretani J./Shamasdin A.*0*1268336593*2-2*00*00*4*6*2*6*0*0*0*0*0*0*20100311/19:00*6*01:04:23";
            //string scores = "1301865066,1301867076,1301865066,20110403@43454*001/ATP+WTA - Miami, USA - Hard - Stadium*Nadal Rafael (ESP)*Djokovic Novak (SRB)*0*1301862684*2-2*00*00*6*4*3*6*6.4*7*0*0*0*0*20110403/18:50*6*03:21:34@43455*001/ATP+WTA - Miami, USA - Hard - Stadium*Huber L./Petrova N. (USA/RUS)*Hantuchova D./Radwanska A. (SVK/POL)*2*0*1-2*30*30*4*3*0*0*0*0*0*0*0*0*20110403/22:30*1*00:33:03@43456*002/ATP Challenger - Barletta, Italy - Clay - Center Court*Volandri Filippo (ITA)*Bedene Aljaz (SLO)*0*1301827516*2-2*00*00*5*7*3*6*0*0*0*0*0*0*20110403/10:30*6*01:48:56@43492*004/ATP Challenger - Barranquilla, Colombia - Clay - Cancha Central*Bagnis Facundo (ARG)*Junqueira Diego (ARG)*1*1301864045*1-1*00*30*1*6*5*5*0*0*0*0*0*0*20110403/22:15*2*01:16:20@43457*005/ATP Challenger - St. Brieuc, France - Clay - Central*Teixeira Maxime (FRA)*Paire Benoit (FRA)*0*1301839337*2-1*00*00*6*3*6*0*0*0*0*0*0*0*20110403/15:00*6*0@43458*006/ATP - Casablanca, Morocco - Clay - Court 2*Peya Alexander (AUT)*Luczak Peter (AUS)*0*1301832548*2-1*00*00*7*6.7*0*6*6*2*0*0*0*0*20110403/12:00*6*01:56:10@43459*006/ATP - Casablanca, Morocco - Clay - Court 2*Niland Conor (IRL)*Smethurst Daniel (GBR)*2*1301837482*2-1*00*30*6.2*7*1*0*0*0*0*0*0*0*20110403/13:30*28*01:23:57@43460*006/ATP - Casablanca, Morocco - Clay - Court 2*Kukushkin Mikhail (KAZ)*Ziadi Mehdi (MAR)*0*1301853005*0*00*00*0*0*0*0*0*0*0*0*0*0*20110403/15:00*Postp.*0@43461*007/ATP - Casablanca, Morocco - Clay - Court 3*Munoz-De La Nava Daniel (ESP)*Devilder Nicolas (FRA)*0*1301834242*2-2*00*00*6*4*3*6*2*6*0*0*0*0*20110403/12:00*6*02:26:43@43462*007/ATP - Casablanca, Morocco - Clay - Court 3*Granollers-Pujol Gerard (ESP)*Carreno-Busta Pablo (ESP)*1*1301836766*2-2*15*30*6*0*2*5*0*0*0*0*0*0*20110403/13:30*28*00:56:03@43463*007/ATP - Casablanca, Morocco - Clay - Court 3*Kumantsov Andrey (RUS)*Gutierrez-Ferrol Sergio (ESP)*0*1301853055*0*00*00*0*0*0*0*0*0*0*0*0*0*20110403/15:00*Postp.*0@43464*008/ATP - Casablanca, Morocco - Clay - Court 6*Kuznetsov Andrey (RUS)*Millot Vincent (FRA)*0*1301830061*2-1*00*00*6*4*6*2*0*0*0*0*0*0*20110403/12:00*6*01:16:48@43465*008/ATP - Casablanca, Morocco - Clay - Court 6*Schukin Yuri (KAZ)*Bautista-Agut Roberto (ESP)*2*1301837727*2-2*00*00*6.5*7*6*4*1*2*0*0*0*0*20110403/13:30*38*02:04:22@43466*009/ATP - Houston, USA - Clay - Court 3*Smyczek Tim (USA)*Bester Philip (CAN)*0*1301851572*2-1*00*00*4*6*6*2*6*4*0*0*0*0*20110403/17:00*6*02:13:26@43467*009/ATP - Houston, USA - Clay - Court 3*Acasuso Jose (ARG)*Karlovic Ivo (CRO)*0*1301861608*2-2*00*00*6.6*7*7*6.9*1*6*0*0*0*0*20110403/18:30*6*02:25:10@43468*009/ATP - Houston, USA - Clay - Court 3*Bogomolov Jr. Alex (USA)*Massu Nicolas (CHI)*1*1301865066*1-2*40*00*6*4*2*1*0*0*0*0*0*0*20110403/20:00*2*01:19:20@43469*010/ATP - Houston, USA - Clay - Court 4*Matosevic Marinko (AUS)*Dancevic Frank (CAN)*0*1301849208*2-2*00*00*6.10*7*1*6*0*0*0*0*0*0*20110403/17:00*6*01:31:50@43470*010/ATP - Houston, USA - Clay - Court 4*Capdeville Paul (CHI)*Kuznetsov Alex (USA)*0*1301855280*2-1*00*00*7*6.6*6*2*0*0*0*0*0*0*20110403/18:30*6*01:25:05@43471*010/ATP - Houston, USA - Clay - Court 4*Young Donald (USA)*Polansky Peter (CAN)*0*1301861076*2-1*00*00*6*3*6*4*0*0*0*0*0*0*20110403/20:00*6*01:17:52@43472*011/ATP - Houston, USA - Clay - Court 5*Yoo Daniel (KOR)*Skugor Franco (CRO)*0*1301854186*2-2*00*00*6*4*0*6*2*6*0*0*0*0*20110403/18:30*6*01:53:45@43473*011/ATP - Houston, USA - Clay - Court 5*Ram Rajeev (USA)*Zemlja Grega (SLO)*0*1301859785*2-1*00*00*6*4*6*3*0*0*0*0*0*0*20110403/20:00*6*01:14:31@43493*013/WTA - Charleston, USA - Clay - Althea Gibson*Birnerova Eva (CZE)*Bychkova Ekaterina (RUS)*0*1301844718*2-1*00*00*6*3*6*2*0*0*0*0*0*0*20110403/16:00*6*01:25:46@43494*013/WTA - Charleston, USA - Clay - Althea Gibson*Watson Heather (GBR)*Wienerova Lenka (SVK)*0*1301851772*2-1*00*00*6*1*7*6.2*0*0*0*0*0*0*20110403/17:30*6*01:37:39@43495*013/WTA - Charleston, USA - Clay - Althea Gibson*Vandeweghe Coco (USA)*Stevenson Alexandra (USA)*0*1301862538*2-2*00*00*2*6*6*2*4*6*0*0*0*0*20110403/19:00*6*02:41:05@43497*014/WTA - Charleston, USA - Clay - Court 3*Falconi Irina (USA)*Foretz Gacon Stephanie (FRA)*0*1301849173*2-1*00*00*7*6.5*7*5*0*0*0*0*0*0*20110403/17:00*6*01:39:38@43498*014/WTA - Charleston, USA - Clay - Court 3*Mirza Sania (IND)*Savchuk Olga (UKR)*0*1301855851*2-1*00*00*6*4*6*3*0*0*0*0*0*0*20110403/19:00*6*01:27:48@43496*014/WTA - Charleston, USA - Clay - Court 3*Dabrowski Gabriela (CAN)*Stephens Sloane (USA)*0*1301863418*2-2*00*00*3*6*1*6*0*0*0*0*0*0*20110403/20:30*6*00:57:37@43499*015/WTA - Charleston, USA - Clay - Court 4*Malek Tatjana (GER)*Puig Monica (PUR)*0*1301853068*2-2*00*00*7*5*4*6*3*6*0*0*0*0*20110403/17:00*6*02:44:56@43500*015/WTA - Charleston, USA - Clay - Court 4*Tatishvili Anna (GEO)*Luzhanska Tetiana (UKR)*0*1301857774*2-1*00*00*6*2*6*2*0*0*0*0*0*0*20110403/19:00*6*01:02:52@43474*016/WTA - Marbella, Spain - Clay - Pista Central*Meusburger Yvonne (AUT)*Torro-Flor Maria-Teresa (ESP)*0*1301827841*2-2*00*00*4*6*5*7*0*0*0*0*0*0*20110403/11:00*6*01:26:43@43475*016/WTA - Marbella, Spain - Clay - Pista Central*Llagostera Vives Nuria (ESP)*Koryttseva Mariya (UKR)*0*1301839552*2-2*00*00*6*4*2*6*4*6*0*0*0*0*20110403/12:30*6*02:16:41@43476*016/WTA - Marbella, Spain - Clay - Pista Central*Camerin Maria Elena (ITA)*Karatantcheva Sesil (KAZ)*0*1301846080*2-1*00*00*6*3*6*2*0*0*0*0*0*0*20110403/14:00*6*01:16:52@43477*016/WTA - Marbella, Spain - Clay - Pista Central*Pipiya Nanuli (RUS)*Arruabarrena-Vecino Lara (ESP)*0*1301854000*2-2*00*00*2*6*2*6*0*0*0*0*0*0*20110403/15:30*6*01:10:19@43478*017/WTA - Marbella, Spain - Clay - Pista 1*Glushko Julia (ISR)*Begu Irina-Camelia (ROU)*0*1301827052*2-2*00*00*4*6*0*6*0*0*0*0*0*0*20110403/11:00*6*01:11:54@43479*017/WTA - Marbella, Spain - Clay - Pista 1*Fernandez-Brugues Eva (ESP)*Dentoni Corinna (ITA)*0*1301838671*2-1*00*00*3*6*6*3*6*2*0*0*0*0*20110403/12:30*6*02:26:32@43480*017/WTA - Marbella, Spain - Clay - Pista 1*Bogdan Elena (ROU)*Bratchikova Nina (RUS)*0*1301850422*2-2*00*00*6*1*4*6*0*6*0*0*0*0*20110403/14:00*6*01:42:29@43481*018/WTA - Marbella, Spain - Clay - Pista 3*Barthel Mona (GER)*Panova Alexandra (RUS)*0*1301828949*2-1*00*00*6*3*6*1*0*0*0*0*0*0*20110403/11:00*6*01:48:04@43482*021/ATP Challenger - Pereira, Colombia - Clay - Centre Court*Campozano Julio Cesar (ECU)*Pastor Nicolas (ARG)*0*1301856419*2-1*00*00*7*5*6.6*7*6*2*0*0*0*0*20110403/17:30*6*32129:40@43501*021/ATP Challenger - Pereira, Colombia - Clay - Centre Court*Zivkovic Dennis (USA)*Zornosa Steffen (COL)*1*1301859632*1-3*40*15*6*1*3*2*0*0*0*0*0*0*20110403/21:00*2*00:51:04@43483*022/ATP Challenger - Pereira, Colombia - Clay - Court 2*Duran Guillermo (ARG)*Benedetti Cristian (ARG)*0*1301853941*2-1*00*00*7*6.4*6*3*0*0*0*0*0*0*20110403/17:30*6*02:15:48@43484*022/ATP Challenger - Pereira, Colombia - Clay - Court 2*Trungelliti Marco (ARG)*Diaz-Barriga Luis (MEX)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110403/19:00*0*0@43485*023/ATP Challenger - Pereira, Colombia - Clay - Court 7*Zornosa Steffen (COL)*Echazu Mauricio (PER)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110403/17:00*0*0@43486*025/ATP Challenger - Recife, Brazil - Hard - Center Court*Lopes Tiago (BRA)*Uebel Lars (GER)*0*1301844589*2-2*00*00*3*6*6*2*6.6*7*0*0*0*0*20110403/15:00*6*02:17:33@43487*026/ATP Challenger - Recife, Brazil - Hard - Court 2*Turini Thales (BRA)*Paterno Fabio (BRA)*0*1301838735*2-1*00*00*6*0*6*0*0*0*0*0*0*0*20110403/15:00*6*00:43:09@43488*027/ATP Challenger - Monza, Italy - Clay - Centrale*Brizzi Alberto (ITA)*Kirche Leonardo (BRA)*0*1301832230*2-1*00*00*5*7*7*6.7*6*3*0*0*0*0*20110403/11:00*6*02:56:22@43489*027/ATP Challenger - Monza, Italy - Clay - Centrale*Crugnola Marco (ITA)*Balleret Benjamin (MON)*0*1301837842*2-2*00*00*4*6*4*6*0*0*0*0*0*0*20110403/12:30*6*01:17:25@43490*027/ATP Challenger - Monza, Italy - Clay - Centrale*Naso Gianluca (ITA)*Oswald Philipp (AUT)*0*1301846857*2-1*00*00*3*6*7*6.2*6*4*0*0*0*0*20110403/14:00*6*02:13:39@43491*028/ATP Challenger - Monza, Italy - Clay - Campo 1*De Schepper Kenny (FRA)*Grassi Claudio (ITA)*0*1301839966*2-1*00*00*6*2*6*0*0*0*0*0*0*0*20110403/15:00*6*01:02:10";
            //string scores = "0,1301899701,0,20110404@43502*001/ATP - Casablanca, Morocco - Clay - Court Central*Kukushkin Mikhail (KAZ)*Ziadi Mehdi (MAR)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/12:00*0*0@43503*001/ATP - Casablanca, Morocco - Clay - Court Central*Andujar Pablo (ESP)*Serra Florent (FRA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/13:30*0*0@43504*001/ATP - Casablanca, Morocco - Clay - Court Central*Phau Bjorn (GER)*Chardy Jeremy (FRA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/15:00*0*0@43505*001/ATP - Casablanca, Morocco - Clay - Court Central*Hanescu Victor (ROU)*Gimeno-Traver Daniel (ESP)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/16:30*0*0@43506*002/ATP - Casablanca, Morocco - Clay - Court 2*Niland Conor (IRL)*Smethurst Daniel (GBR)*2*0*0*00*30*6.2*7*1*0*0*0*0*0*0*0*20110404/12:00*0*0@43507*002/ATP - Casablanca, Morocco - Clay - Court 2*Devilder Nicolas (FRA)*Peya Alexander (AUT)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/13:00*0*0@43508*002/ATP - Casablanca, Morocco - Clay - Court 2*Riba Pere (ESP)*Huta Galung Jesse (NED)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/16:00*0*0@43509*003/ATP - Casablanca, Morocco - Clay - Court 3*Granollers-Pujol Gerard (ESP)*Carreno-Busta Pablo (ESP)*1*0*0*15*30*6*0*2*5*0*0*0*0*0*0*20110404/12:00*0*0@43510*003/ATP - Casablanca, Morocco - Clay - Court 3*Montanes A./Montanes-Roca F. (ESP)*Marrero D./Ramirez Hidalgo R. (ESP)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/17:00*0*0@43511*004/ATP - Casablanca, Morocco - Clay - Court 6*Schukin Yuri (KAZ)*Bautista-Agut Roberto (ESP)*2*0*0*00*00*6.5*7*6*4*1*2*0*0*0*0*20110404/12:00*0*0@43512*005/ATP - Casablanca, Morocco - Clay - Court 7*Kumantsov Andrey (RUS)*Gutierrez-Ferrol Sergio (ESP)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/12:00*0*0@43513*007/ATP - Houston, USA - Clay - Stadium*Berlocq C./Gabashvili T. (ARG/RUS)*Murray J./Zverev M. (GBR/GER)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/19:00*0*0@43514*007/ATP - Houston, USA - Clay - Stadium*Mello Ricardo (BRA)*Cuevas Pablo (URU)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/20:30*0*0@43515*007/ATP - Houston, USA - Clay - Stadium*Dimitrov Grigor (BUL)*Schuettler Rainer (GER)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/22:00*0*0@43516*007/ATP - Houston, USA - Clay - Stadium*Andreev Igor (RUS)*Russell Michael (USA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110405/01:00*0*0@43517*007/ATP - Houston, USA - Clay - Stadium*Kudla D./Young D. (USA)*Ferreiro F./Sa A. (BRA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110405/02:30*0*0@43518*008/ATP - Houston, USA - Clay - Court 3*Young Donald (USA)*Karlovic Ivo (CRO)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/18:00*0*0@43519*008/ATP - Houston, USA - Clay - Court 3*Capdeville Paul (CHI)*Ram Rajeev (USA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/19:30*0*0@43520*009/ATP - Houston, USA - Clay - Court 7*Dancevic Frank (CAN)*Smyczek Tim (USA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/18:00*0*0@43521*009/ATP - Houston, USA - Clay - Court 7*Bogomolov Jr. Alex (USA)*Skugor Franco (CRO)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/19:30*0*0@43522*011/WTA - Charleston, USA - Clay - Stadium*Dushevina Vera (RUS)*King Vania (USA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/16:00*0*0@43523*011/WTA - Charleston, USA - Clay - Stadium*Rogers Shelby (USA)*Craybas Jill (USA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/17:30*0*0@43524*011/WTA - Charleston, USA - Clay - Stadium*Scheepers Chanelle (RSA)*Schnyder Patty (SUI)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/19:00*0*0@43525*011/WTA - Charleston, USA - Clay - Stadium*Mattek-Sands Bethanie (USA)*Stevenson Alexandra (USA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/20:30*0*0@43526*012/WTA - Charleston, USA - Clay - Althea Gibson*Govortsova Olga (BLR)*Goerges Julia (GER)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/16:00*0*0@43527*012/WTA - Charleston, USA - Clay - Althea Gibson*Watson Heather (GBR)*McHale Christina (USA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/17:30*0*0@43528*012/WTA - Charleston, USA - Clay - Althea Gibson*Mirza Sania (IND)*Riske Alison (USA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/19:00*0*0@43529*012/WTA - Charleston, USA - Clay - Althea Gibson*Stephens Sloane (USA)*Peng Shuai (CHN)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/20:30*0*0@43530*013/WTA - Charleston, USA - Clay - Court 3*Lucic Mirjana (CRO)*Morita Ayumi (JPN)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/16:00*0*0@43531*013/WTA - Charleston, USA - Clay - Court 3*Cornet Alize (FRA)*Arvidsson Sofia (SWE)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/17:30*0*0@43532*013/WTA - Charleston, USA - Clay - Court 3*Vesnina Elena (RUS)*Marino Rebecca (CAN)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/19:00*0*0@43533*013/WTA - Charleston, USA - Clay - Court 3*Zheng Jie (CHN)*Puig Monica (PUR)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/20:30*0*0@43534*014/WTA - Charleston, USA - Clay - Court 4*Martic Petra (CRO)*Rodina Evgeniya (RUS)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/16:00*0*0@43535*014/WTA - Charleston, USA - Clay - Court 4*Birnerova Eva (CZE)*Czink Melinda (HUN)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/17:30*0*0@43536*014/WTA - Charleston, USA - Clay - Court 4*Rybarikova Magdalena (SVK)*Falconi Irina (USA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/19:00*0*0@43537*014/WTA - Charleston, USA - Clay - Court 4*Ondraskova Zuzana (CZE)*Rodionova Anastasia (AUS)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/20:30*0*0@43538*016/WTA - Marbella, Spain - Clay - Pista Central*Koryttseva Mariya (UKR)*Begu Irina-Camelia (ROU)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/11:00*0*0@43539*016/WTA - Marbella, Spain - Clay - Pista Central*Dulgheru Alexandra (ROU)*Pivovarova Anastasia (RUS)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/12:30*0*0@43540*016/WTA - Marbella, Spain - Clay - Pista Central*Hercog Polona (SLO)*Pous-Tio Laura (ESP)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/14:00*0*0@43541*016/WTA - Marbella, Spain - Clay - Pista Central*Cirstea Sorana (ROU)*Errani Sara (ITA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/15:30*0*0@43542*017/WTA - Marbella, Spain - Clay - Pista 1*Torro-Flor Maria-Teresa (ESP)*Fernandez-Brugues Eva (ESP)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/11:00*0*0@43543*017/WTA - Marbella, Spain - Clay - Pista 1*Vinci Roberta (ITA)*Zahlavova Sandra (CZE)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/12:30*0*0@43544*017/WTA - Marbella, Spain - Clay - Pista 1*Safina D./Szavay A. (RUS/HUN)*Jans K./Rosolska A. (POL)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/14:00*0*0@43545*017/WTA - Marbella, Spain - Clay - Pista 1*Daniilidou E./Panova A. (GRE/RUS)*Llagostera Vives N./Parra Santonja A. (ESP)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/15:30*0*0@43546*018/WTA - Marbella, Spain - Clay - Pista 7*Camerin Maria Elena (ITA)*Barthel Mona (GER)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/11:00*0*0@43547*018/WTA - Marbella, Spain - Clay - Pista 7*Zakopalova Klara (CZE)*Yakimova Anastasiya (BLR)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/12:30*0*0@43548*018/WTA - Marbella, Spain - Clay - Pista 7*Larsson J./Meusburger Y. (SWE/AUT)*Garcia Vidagany B./Soler Espinosa S. (ESP)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/14:00*0*0@43549*019/WTA - Marbella, Spain - Clay - Pista 3*Arruabarrena-Vecino Lara (ESP)*Bratchikova Nina (RUS)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/11:00*0*0@43550*021/ATP Challenger - Pereira, Colombia - Clay - Centre Court*Farah Robert (COL)*Estrella Victor (DOM)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/17:30*0*0@43551*021/ATP Challenger - Pereira, Colombia - Clay - Centre Court*Kim Kevin (USA)*Cabal Juan Sebastian (COL)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/19:00*0*0@43552*021/ATP Challenger - Pereira, Colombia - Clay - Centre Court*Dutra Da Silva Rogerio (BRA)*Brzezicki Juan Pablo (ARG)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/20:30*0*0@43553*022/ATP Challenger - Pereira, Colombia - Clay - Court 2*Aguilar Jorge (CHI)*Barrientos Nicolas (COL)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/17:30*0*0@43554*022/ATP Challenger - Pereira, Colombia - Clay - Court 2*Molteni Andres (ARG)*Prodon Eric (FRA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/19:00*0*0@43555*022/ATP Challenger - Pereira, Colombia - Clay - Court 2*Felder M./Salamanca C. (URU/COL)*Campozano J. C./Decoud S. (ECU/ARG)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/20:30*0*0@43556*022/ATP Challenger - Pereira, Colombia - Clay - Court 2*Burrieza O./Marti J. (ESP)*Duclos P.-L./Ward J. (CAN/GBR)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/22:00*0*0@43557*023/ATP Challenger - Pereira, Colombia - Clay - Court 7*Ghedin R./Lorenzi P. (ITA)*Sykut M./Zivkovic D. (USA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/17:30*0*0@43558*023/ATP Challenger - Pereira, Colombia - Clay - Court 7*Pastor N./Trungelliti M. (ARG)*Escobar F./Lopez S. (COL)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/19:00*0*0@43559*023/ATP Challenger - Pereira, Colombia - Clay - Court 7*Diaz-Barriga L./Estrella V. (MEX/DOM)*Alund M./Duran G. (ARG)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/20:30*0*0@43560*023/ATP Challenger - Pereira, Colombia - Clay - Court 7*Gomez J. S./Kim K. (COL/USA)*Aguilar J./Garza D. (CHI/MEX)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/22:00*0*0@43561*025/ATP Challenger - Recife, Brazil - Hard - Center Court*Silva Julio (BRA)*Yang Tsung-Hua (TPE)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/15:00*0*0@43562*025/ATP Challenger - Recife, Brazil - Hard - Center Court*Chiudinelli Marco (SUI)*Clezar Guilherme (BRA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/16:30*0*0@43563*025/ATP Challenger - Recife, Brazil - Hard - Center Court*Laranja Augusto (BRA)*Pereira Jose (BRA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/18:30*0*0@43564*025/ATP Challenger - Recife, Brazil - Hard - Center Court*Fernandes T./Yang T.-H. (BRA/TPE)*Lindell C./Maynard V. (SWE/BRA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/20:00*0*0@43565*026/ATP Challenger - Recife, Brazil - Hard - Court 2*Santanna Bruno (BRA)*Romboli Fernando (BRA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/15:00*0*0@43566*026/ATP Challenger - Recife, Brazil - Hard - Court 2*Nieminen Timo (FIN)*Silva Daniel (BRA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/16:30*0*0@43567*026/ATP Challenger - Recife, Brazil - Hard - Court 2*Hocevar R./Lopes T. (BRA)*Lapentti G./Romboli F. (ECU/BRA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/19:00*0*0@43568*026/ATP Challenger - Recife, Brazil - Hard - Court 2*Belyaev I./Menendez-Maceiras A. (RUS/ESP)*Matos D./Miele A. (BRA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/20:30*0*0@43569*027/ATP Challenger - Recife, Brazil - Hard - Court 3*Belyaev Ilya (RUS)*Guidolin Rodrigo (BRA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/15:00*0*0@43570*027/ATP Challenger - Recife, Brazil - Hard - Court 3*Moser Nikolaus (AUT)*Turini Thales (BRA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/16:30*0*0@43571*027/ATP Challenger - Recife, Brazil - Hard - Court 3*Arguello F./Galdon P. (ARG)*Borvanov R./Zampieri C. (MDA/BRA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/19:00*0*0@43572*029/ATP Challenger - Monza, Italy - Clay - Centrale*Delgado J./Marray J. (GBR)*Martin D./Slanar M. (USA/AUT)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/11:30*0*0@43573*029/ATP Challenger - Monza, Italy - Clay - Centrale*Knittel Bastian (GER)*Ilhan Marsel (TUR)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/13:00*0*0@43574*029/ATP Challenger - Monza, Italy - Clay - Centrale*De Schepper Kenny (FRA)*Gremelmayr Denis (GER)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/14:30*0*0@43575*029/ATP Challenger - Monza, Italy - Clay - Centrale*Beck Andreas (GER)*Viola Matteo (ITA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/17:30*0*0@43576*030/ATP Challenger - Monza, Italy - Clay - Campo 1*Emmrich M./Kowalczyk M. (GER/POL)*Brunstrom J./Nielsen F. (SWE/DEN)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/11:30*0*0@43577*030/ATP Challenger - Monza, Italy - Clay - Campo 1*Donskoy Evgeny (RUS)*Grigelis Laurynas (LTU)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/13:00*0*0@43578*030/ATP Challenger - Monza, Italy - Clay - Campo 1*Kravchuk Konstantin (RUS)*Del Bonis Federico (ARG)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/14:30*0*0@43579*030/ATP Challenger - Monza, Italy - Clay - Campo 1*Cotto N./Dupuy Y. (ITA/FRA)*Greul S./Raja P. (GER/IND)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/16:00*0*0@43580*030/ATP Challenger - Monza, Italy - Clay - Campo 1*Junaid R./Kerr J. (AUS)*Di Mauro A./Vagnozzi S. (ITA)*0*0*0*00*00*0*0*0*0*0*0*0*0*0*0*20110404/17:30*0*0";

            string[] all = scores.Split('@');

            int numOfMatches = (all.Length) - 1;

            // only parse if match data exists
            if (numOfMatches > 0)
            {
                string origTournamentName = string.Empty;
                for (int m = 1; m < numOfMatches + 1; m++)  // 0 index does not contain match data
                {
                    Match match = new Match();
                    
                    string[] matchdata = all[m].Split('*');
                    string tournament = matchdata[1].Split('/')[1];
                    string firstplayer = matchdata[2];
                    string secondplayer = matchdata[3];

                    string matchDate = matchdata[19].Split('/')[0];
                    string matchTime = GetProperMatchTime(matchdata[21]);
                    
                    string winner = matchdata[6];
                    if (winner != "0")
                        winner = matchdata[6].Split('-')[1];
                    
                    string isFinished = (matchdata[20]);

                    Player player1 = new Player();
                    player1.Name = firstplayer;

                    Player player2 = new Player();
                    player2.Name = secondplayer;

                    if (winner.Equals("1") && isFinished.Equals("6"))
                    {
                        player1.IsWinner = true;
                        player2.IsWinner = false;
                        match.InProgress = false;
                        match.Status = MatchProgress.FINISHED;
                    }

                    else if (winner.Equals("2") && isFinished.Equals("6"))
                    {
                        player2.IsWinner = true;
                        player1.IsWinner = false;
                        match.InProgress = false;
                        match.Status = MatchProgress.FINISHED;
                    }

                    else if (isFinished.Equals("0"))
                    {
                        player1.IsWinner = false;
                        player2.IsWinner = false;
                        match.InProgress = false;
                        match.Status = MatchProgress.NOT_STARTED;
                    }

                    else
                    {
                        player1.IsWinner = false;
                        player2.IsWinner = false;
                        match.InProgress = true;
                        match.Status = MatchProgress.IN_PLAY;
                    }

                    // create temporary collections to hold set scores
                    List<int> player1gameswon = new List<int>();
                    List<int> player2gameswon = new List<int>();

                    for (var i = 9; i < 19; i++)
                    {  
                        // start of score starts at index 9 and there are 10 sets for both players (assumes 5 sets per player --> 9 + 10 = 19 indexs reserved for set scores)
                        if (i % 2 != 0)
                        {
                            // 5/24/10 - for some reason game point is returning blank rather than zero
                            // 4/05/11 - game score returns question mark
                            if (matchdata[i].Equals(string.Empty) || matchdata[i].Equals("?"))
                                player1gameswon.Add(0);
                            // 4/3/11 - for some reason game point contains decimal point, maybe representing tiebreak score
                            else if (matchdata[i].IndexOf(".") > -1)
                                player1gameswon.Add(int.Parse(matchdata[i].Substring(0, 1)));
                            else
                                player1gameswon.Add(int.Parse(matchdata[i]));
                        }
                        else
                        {
                            if (matchdata[i].Equals(string.Empty) || matchdata[i].Equals("?"))
                                player2gameswon.Add(0);
                            else if (matchdata[i].IndexOf(".") > -1)
                                player2gameswon.Add(int.Parse(matchdata[i].Substring(0, 1)));
                            else
                                player2gameswon.Add(int.Parse(matchdata[i]));
                        }
                    }

                    int setNum;
                    int player1GamePoint;
                    int player2GamePoint;

                    // remove 0-0 sets from game scores
                    for (int i = 0; i < 5; i++)
                    {
                        setNum = i + 1;
                        player1GamePoint = player1gameswon[i];
                        player2GamePoint = player2gameswon[i];

                        //// only attempt to add set to collection if set score is not 0-0
                        if (!(player1GamePoint.Equals(0) && player2GamePoint.Equals(0)))
                        {
                            // determine winner of set (assuming match is complete)
                            if (match.InProgress == false)
                            {
                                // player 1 won set
                                if (player1gameswon[i] > player2gameswon[i])
                                {
                                    player1.GamesWon.Add(new GamePoint(player1GamePoint, setNum, true));
                                    player2.GamesWon.Add(new GamePoint(player2GamePoint, setNum, false));
                                }

                                // player 2 won set
                                else
                                {
                                    player1.GamesWon.Add(new GamePoint(player1GamePoint, setNum, false));
                                    player2.GamesWon.Add(new GamePoint(player2GamePoint, setNum, true));
                                }
                            }

                            else
                            {
                                player1.GamesWon.Add(new GamePoint(player1GamePoint));
                                player2.GamesWon.Add(new GamePoint(player2GamePoint));
                            }
                        }
                    }

                    string[] matchDetails = tournament.Split('-');
                    //match.Court = tournament.Split('-')[0] + tournament.Split('-')[1] + tournament.Split('-')[2]; //tournament.Split('-')[3];
                    //match.MatchIndex = m;
                    match.Tournament = matchDetails[1].Trim();
                    match.SurfaceType = matchDetails[2].Trim();
                    match.Court = matchDetails[3].Trim();
                    match.Player1 = player1;
                    match.Player2 = player2;
                    match.Duration = matchTime;
                    match.DatePlayed = new DateTime(int.Parse(matchDate.Substring(0,4)), int.Parse(matchDate.Substring(4, 2)), int.Parse(matchDate.Substring(6, 2)));

                    // only add singles matches for now
                    if (player1.Name.IndexOf("/") == -1)
                    {
                        match.MatchIndex = singles.Count + 1;
                        match.MatchType = MatchTypes.SINGLES;
                        singles.Add(match);
                    }

                    else
                    {
                        match.MatchIndex = doubles.Count + 1;
                        match.MatchType = MatchTypes.DOUBLES;
                        doubles.Add(match);
                    }
                }
            }

            TennisScoresCollection tennis = new TennisScoresCollection();

            // order matches by tournament name and match status
            // commented out b/c ordering makes paging index value out of order
            /*
            var matches1 = from element in doubles
                           orderby element.Tournament, element.Status descending
                           select element;

            var matches2 = from element in singles
                           orderby element.Tournament, element.Status descending
                           select element;

            tennis.Doubles = matches1.ToList();
            tennis.Singles = matches2.ToList();
            */

            tennis.Doubles = doubles;
            tennis.Singles = singles;

            return tennis;
        }

        private string GetProperMatchTime(string matchTime)
        {
            if (matchTime.IndexOf(":") > -1)
            {
                return matchTime;
            }
            else
            {
                DateTime convertedDateTime = ConvertFromTimestamp(double.Parse(matchTime));
                return convertedDateTime.ToShortTimeString();
            }
        }

        /// <summary>
        /// method for converting unix timestamp to DateTime format
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        private DateTime ConvertFromTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}
