namespace FSlugify

module CharMaps =

    let InternalCharMap = Map.ofArray [|
        // Acute accents
        ('á', 'a'); ('Á', 'A');
        ('é', 'e'); ('É', 'E');
        ('í', 'i'); ('Í', 'I');
        ('ó', 'o'); ('Ó', 'O');
        ('ú', 'u'); ('Ú', 'U');
        ('ý', 'y'); ('Ý', 'Y');
        // Circumflex accents
        ('â', 'a'); ('Â', 'A');
        ('ê', 'e'); ('Ê', 'E');
        ('î', 'i'); ('Î', 'I');
        ('ô', 'o'); ('Ô', 'O');
        ('û', 'u'); ('Û', 'U');
        // Umlaut/Dieresis accents
        ('ä', 'a'); ('Ä', 'A');
        ('ë', 'e'); ('Ë', 'E');
        ('ï', 'i'); ('Ï', 'I');
        ('ö', 'o'); ('Ö', 'O');
        ('ü', 'u'); ('Ü', 'U');
        // Grave accents
        ('à', 'a'); ('À', 'A');
        ('è', 'e'); ('È', 'E');
        ('ì', 'i'); ('Ì', 'I');
        ('ò', 'o'); ('Ò', 'O');
        ('ù', 'u'); ('Ù', 'U');
        // Tilde accents
        ('ã', 'a'); ('Ã', 'A');
        ('ñ', 'n'); ('Ñ', 'N');
        ('õ', 'o'); ('Õ', 'O');
        // Cedilla accent
        ('ç', 'c'); ('Ç', 'C');
    |]