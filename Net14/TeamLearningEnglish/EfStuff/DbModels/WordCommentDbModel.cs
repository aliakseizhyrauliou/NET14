﻿namespace TeamLearningEnglish.EfStuff.DbModels
{
    public class WordCommentDbModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual WordDbModel Word { get; set; }
    }
}
