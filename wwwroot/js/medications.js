const commonMeds = [
    // Ağrı Kesiciler ve Ateş Düşürüciler
    "Arveles", "Parol", "Aspirin", "Majezik", "Apranax Plus", "Apranax Forte", "Vermidon", "Minoset", "Minoset Plus", "Panadol",
    "Geralgine Plus", "Geralgine K", "Advil Liquigel", "Nurofen", "Nurofen Cold", "Dolorex", "Dex-Forte", "Dolarit", "Etol Fort", "Bi-Profid",
    "Kataflam", "Voltaren SR 75", "Voltaren Flash", "Dikloron", "Diklomec", "Etofast", "Fenistil Gel", "Fastjel", "Naprosyn", "Aleve",
    "A-Ferin Forte", "A-Ferin Sinus", "Tylolhot", "Katarin Forte", "Theraflu Forte", "Corsal", "Deflu", "Peditus", "Calpol", "Ibufen",
    
    // Antibiyotikler
    "Augmentin BID", "Amoklavin BID", "Klamoks BID", "Largopen", "Alfasilin", "Duocid", "Combicid", "Zinnat", "Aksef", "Enfexia",
    "Cefaks", "Sefazol", "Rocephin", "Iespor", "Klacid", "Macrol", "Maksipor", "Zitromax", "Azitro", "Cipro",
    "Siprobel", "Siproktin", "Tavanic", "Avelox", "Moxiflox", "Flagyl", "Nidazol", "Bactrim", "Trimoks", "Monurol",
    "Tetradox", "Monodoks", "Amoksilin", "Ampisilin", "Penisilin", "Klaritromisin", "Azitromisin", "Sefaleksin", "Sefuroksim", "Seftriakson",
    
    // Mide ve Sindirim Sistemi
    "Lansor", "Lansazol", "Degastrol", "Nexium", "Esomep", "Emanera", "Pantpas", "Pulcet", "Gastazol", "Panto",
    "Gaviscon Liquid", "Gaviscon Advance", "Rennie", "Talcid", "Emedur", "Metpamid", "Motilium", "Buscopan", "Buscopan Plus", "Molusk",
    "Laxoberon", "Bekunis", "Duphalac", "Osmolak", "Dicetel", "Meteospasmyl", "Debridat", "Tranko-Buskas", "Famodin", "Zantac",
    
    // Kalp ve Damar Sistemi
    "Coraspin", "Ecopirin", "Vasoxen", "Beloc ZOK", "Dideral", "Saneloc", "Diltizem", "Nidilat", "Norvasc", "Vazkor",
    "Amlocard", "Co-Diovan", "Karvezea", "Hyzaar", "Micardis Plus", "Atacand Plus", "Exforge", "Coveram", "Co-Irbekor", "Olmetec",
    "Lipitor", "Ator", "Cholvastin", "Crestor", "Rosuvas", "Zocor", "Deltarinol", "Plavix", "Pingel", "Coumadin",
    
    // Solunum Sistemi ve Alerji
    "Ventolin", "Aircomb", "Singulair", "Notta", "Desyrel", "Aerius", "Deloday", "Cetryn", "Allerset", "Zyrtec",
    "Avamys", "Nasonex", "Nazoster", "Otrivin", "Iliadin", "Burnon", "Levmont", "Fixdual", "Kestine", "Rupafin",
    "Symbicort", "Foster", "Seretide", "Pulmicort", "Bricanyl", "Asist", "Sandoz Acetylcysteine", "Mucomax", "Nac 600", "Extal",
    
    // Vitaminler ve Takviyeler
    "Supradyn Energy Focus", "Pharmaton Vitality", "Solgar Formula VM-75", "Solgar B-Complex", "Solgar Vitamin C", "Zade Vital", "Ester-C", "Redoxon", "Magnorm", "Magnerot",
    "Osteocare", "Calcimax D3", "Devit-3", "Monovit D3", "Coenzym Q10", "Omega 3-6-9", "Efa S-1200", "Imunex", "Imunaks", "Sambucol",
    "Ferro Sanol Duodenal", "Gyno-Tardyferon", "Maltofer", "Ferrum Hausmann", "B12 Dodex", "Neurobion", "Benexol B12", "Apikobal", "Bemiks", "Tribeksol",
    
    // Diyabet ve Endokrin
    "Matofin", "Glifor", "Glucophage", "Diaformin", "Janumet", "Galvus Met", "Diamicron", "Amaryl", "Glukofen", "Glimax",
    "Euthyrox", "Levotiron", "Tiromel", "Glucobay", "Victosa", "Humalog", "NovoRapid", "Lantus", "Toujeo", "Levemir",
    
    // Sinir Sistemi ve Psikiyatri
    "Xanax", "Diazem", "Lustral", "Selectra", "Paxil", "Paxera", "Cipram", "Citoles", "Cipralex", "Secita",
    "Efexor XR", "Venegis", "Cymbalta", "Duloxx", "Remeron", "Redepra", "Trittico", "Desyrel", "Stilnox", "Lansara",
    "Ritalin", "Concerta", "Laroxyl", "Seroquel", "Cedrina", "Gyrex", "Rexapin", "Olanzapin", "Risperdal", "Abilify",
    
    // Cilt ve Krem
    "Bepanthol", "Fucidin", "Terramycin", "Bacitracin", "Madecassol", "Hametan", "Travazol", "Travocort", "Fito", "Silverdin",
    "Stafine", "Bactroban", "Mupiron", "Contractubex", "Expigment", "Acnelyse", "Roaccutane", "Zoretanin", "Locoid", "Advantan",
    
    // İlave 300+ İlaç (Karma liste - Genel Sağlık)
    "Abhayrab", "Abilify Maintena", "Abrasit", "Abraxane", "Acarel", "Aceclofen", "Acerol", "Acetadote", "Acetium", "Acetylcystein",
    "Aclasta", "Acne-free", "Acnemix", "Acnilox", "Acnotrent", "Actemra", "Actilyse", "Actonel", "Actos", "Acular",
    "Adacel", "Adalat Crono", "Adasuve", "Adcetris", "Addamel N", "Addaven", "Adefovir", "Adempas", "Adenosin", "Adenuric",
    "Adoport", "Adremin", "Adrenalin", "Adriamycin", "Advagraf", "Advantan S", "Advate", "Adynovi", "Aerinaze", "Aflibercept",
    "Aflunext", "Afluon", "Afme", "Agenerase", "Aggrastat", "Agopton", "Agrylin", "Airomir", "Aizostin", "Aknegran",
    "Aknetrent", "Aknilox", "Akoven", "Akseft", "Aksine", "Alat", "Alatab", "Albunorm", "Alburex", "Aldactazide",
    "Aldactone", "Aldara", "Alde", "Aldomet", "Aldurazyme", "Alecensa", "Alendronat", "Alendronik", "Alendros", "Alenit",
    "Alental", "Alenwin", "Aleve", "Alexan", "Alfare", "Alfasilin", "Alfasit", "Alfatol", "Alfoxil", "Alge",
    "Alges", "Algetam", "Algifed", "Algifen", "Algo-Baby", "Algopet", "Algopirin", "Algosedit", "Algostop", "Algotreat",
    "Alimta", "Alitret", "Alka-Seltzer", "Alkeran", "Allegra", "Allergodil", "Allitrate", "Allo", "Allopurinol", "Almora",
    "Alocril", "Alomide", "Alora", "Aloxi", "Aloxi", "Alphamox", "Alphagan P", "Alphanate", "Alprostadil", "Altuzan",
    "Alvesco", "Amantadin", "Amarel", "Ambene", "Ambisome", "Ambrosol", "Amen", "Amerge", "Amikasin", "Amikin",
    "Amisülprid", "Amitriptilin", "Amlodara", "Amlodis", "Amlodipin", "Amoklar", "Amoklavin BID", "Amonyak", "Amosilin", "Amosrit",
    "Amoxicillin", "Amoxil", "Amphotericin B", "Ampiklo", "Ampisina", "Ampisül", "Ampyra", "Amsat", "Amvidon", "Amyl nitrite",
    "Amyvid", "Anadin", "Anafranil", "Anagrelid", "Anakinra", "Anakinra", "Anakit", "Anapen", "Anaphalon", "Anapolon",
    "Anaprox", "Anartrit", "Anastrozol", "Anatab", "Anavar", "Anazol", "Andacal", "Andante", "Andazol", "Andolor",
    "Andozin", "Andractim", "Andriol", "Androcur", "Androderm", "Androgel", "Androlon", "Andronet", "Andropen", "Anemid",
    "Anestezol", "Anexate", "Anfebutam", "Anfen", "Anfex", "Angeliq", "Anginex", "Anginol", "Angiocass", "Angioseal",
    "Angiotan", "Anidulafungin", "Anit", "Anoro", "Ansaid", "Antabus", "Antacid", "Antak", "Antenon", "Antergan",
    "Antialerjik", "Antibasin", "Antibiyotik", "Antidrop", "Antiepileptik", "Antifungal", "Antigribal", "Antihistaminik", "Antik",
    "Antikol", "Antikor", "Antimikrobiyal", "Antinöropatik", "Antipsikotik", "Antisel", "Antisida", "Antispazmodik", "Antisüspansiyon", "Antisüspansiyon",
    "Antivert", "Antiviral", "Antivirüs", "Antizol", "Anuzol", "Anvidon", "Anxiety", "Anzemet", "Anzitel", "Apidra",
    "Apikobal", "Apisiv", "Apixaban", "Apizola", "Aplysia", "Apofin", "Apokyn", "Apolon", "Apomorphine", "Apotex",
    "Apraljin", "Apranax", "Apraz", "Aprepitant", "Apresoline", "Aprokam", "Aprol", "Aprosadyl", "Aprovel", "Apsen",
    "Apsolol", "Aptamil", "Aptivus", "Apx", "Aqua", "Aquacare", "Aquaforte", "Aquamox", "Aquasol", "Aralast",
    "Aranesp", "Arava", "Arcalion", "Arcoxia", "Arduan", "Aredia", "Arepan", "Arestin", "Arflex", "Argatroban",
    "Argeflox", "Aricept", "Arimidex", "Arixtra", "Arkeozin", "Arkinil", "Arlamol", "Arlevert", "Arlin", "Armodafinil",
    "Aronal", "Aromasin", "Arovit", "Arpraz", "Arranon", "Arsant", "Arsenic", "Arsenit", "Arsit", "Artane",
    "Artegain", "Artemis", "Artenak", "Arter", "Artesun", "Arthril", "Arthrotec", "Articaine", "Articlo", "Artifech",
    "Artifol", "Artifort", "Artigesic", "Artilox", "Artis", "Artivit", "Artradol", "Artrex", "Artrodar", "Artron",
    "Artroplus", "Artrotec", "Artrozin", "Artu", "Arveles", "Arvepro", "Arvind", "Arya", "Arymo", "Aryt",
    "Asab", "Asacol", "Asafen", "Asalit", "Asam", "Asaphen", "Asaprol", "Asasantin", "Asavin", "Asawin",
    "Ascorbic", "Ascovit", "Asep", "Asepsin", "Aseptin", "Asetilsalisilik", "Asid", "Asidrin", "Asist", "Asiviral",
    "Askorbik", "Asmanex", "Asmavis", "Asparc", "Asparaginase", "Aspart", "Aspegic", "Aspen", "Asperat", "Aspergin",
    "Asperoc", "Asperon", "Asperwin", "Aspifort", "Aspigrip", "Aspikol", "Aspipirin", "Aspir", "Aspirin", "Aspivat",
    "Aspiwin", "Aspox", "Aspro", "Asr", "Ast", "Astacin", "Astamin", "Astapen", "Astaprim", "Astavir",
    "Astazin", "Astelin", "Aster", "Asthalin", "Asthma", "Astican", "Astif", "Astigrip", "Astimal", "Astimin",
    "Astin", "Astine", "Astramorf", "Astrid", "Astron", "Astropen", "Astyx", "Asum", "Asv", "Asytin",
    "Atabak", "Atacand", "Atad", "Atalren", "Atanol", "Atarax", "Atasol", "Atavis", "Atazanavir", "Atelvia",
    "Atenid", "Atenol", "Atenolol", "Atep", "Atgam", "Atharal", "Atid", "Atis", "Ativan", "Atizol",
    "Atoka", "Atol", "Atomat", "Atop", "Atopan", "Atopic", "Ator", "Atorid", "Atorix", "Atormed",
    "Atorva", "Atorvastat", "Atorvastatin", "Atos", "Atosiban", "Atov", "Atovaquone", "Atovax", "Atovis", "Atovox"
];

const expandedMedicineList = commonMeds;
