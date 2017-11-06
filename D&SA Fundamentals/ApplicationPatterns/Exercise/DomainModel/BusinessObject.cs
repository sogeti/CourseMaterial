using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebShop.DomainModel
{
    public abstract class BusinessObject
    {
        [Required(ErrorMessage="Id is required")]
        [Range(0,Int32.MaxValue)]
        [Key()]
        public int Id { get; set; }

        public virtual bool IsValid
        {
            get
            {
                List<ValidationResult> result = new List<ValidationResult>();
                if (Validator.TryValidateObject(this, new ValidationContext(this), result, true))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public static bool operator ==(BusinessObject b1, BusinessObject b2)
        {
            if ((object)b1 == null || (object)b2 == null)
            {
                return (object) b1 == (object) b2;
            }
            return (b1.Id == b2.Id);
        }

        public static bool operator !=(BusinessObject b1, BusinessObject b2)
        {

            return !(b1 == b2);
        }

        public override bool Equals(Object obj)
        {
            BusinessObject b1 = obj as BusinessObject;
            if ((object)b1 == null)
            {
                return false;
            }
            return (this.Id == b1.Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }       
    }
}
