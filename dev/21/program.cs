    enum Suit
    {
        Diamonds, //    Бубны
        Hearts, //  Червы/черви
        Spades, //  Пики
        Clubs //  Трефы
    }

    struct Card
    {
        public Suit Suit;
        // public int Value; // ценность карты // если писать перечисление, то ценность не нужна(?)
        public string Name; // имя (?)
    }
