﻿using LigamaniaCoreApp.Data.DataModels.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.DataModels.Base.Model
{
    public abstract class Entity : BaseEntity, IEntity
    {
        public virtual int Id { get; set; }
    }
}
