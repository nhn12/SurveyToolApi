﻿using Core.DataContext;
using EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SurveyToolDbContext : EfDataContext
    {
        public SurveyToolDbContext()
            : base("SurveyToolDbContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<OptionChoice> OptionChoices { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<SubUserSurvey> SubUserSurveys { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
         .HasMany(e => e.SubUserSurveys)
         .WithRequired(e => e.Survey)
         .HasForeignKey(e => e.IdSurvey)
         .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SubUserSurveys)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);
        }


    }
}
