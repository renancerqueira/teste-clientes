using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace clientes.domain.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class CPFModel : IEquatable<CPFModel>, IModel
    {
        /// <summary>
        /// Gets or Sets Numero
        /// </summary>
        [Required]
        [DataMember(Name = "numero")]
        public string Numero { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return Numero;
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CPFModel)obj);
        }

        /// <summary>
        /// Returns true if CPF instances are equal
        /// </summary>
        /// <param name="other">Instance of CPF to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CPFModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Numero == other.Numero ||
                    Numero != null &&
                    Numero.Equals(other.Numero)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Numero != null)
                    hashCode = hashCode * 59 + Numero.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(CPFModel left, CPFModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CPFModel left, CPFModel right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
