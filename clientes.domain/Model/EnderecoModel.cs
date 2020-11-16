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
    public partial class EnderecoModel : IEquatable<EnderecoModel>, IModel
    {
        /// <summary>
        /// Gets or Sets Logradouro
        /// </summary>
        [Required]
        [DataMember(Name = "logradouro")]
        [MaxLength(50)]
        public string Logradouro { get; set; }

        /// <summary>
        /// Gets or Sets Bairro
        /// </summary>
        [Required]
        [DataMember(Name = "bairro")]
        [MaxLength(40)]
        public string Bairro { get; set; }

        /// <summary>
        /// Gets or Sets Cidade
        /// </summary>
        [Required]
        [DataMember(Name = "cidade")]
        [MaxLength(40)]
        public string Cidade { get; set; }

        /// <summary>
        /// Gets or Sets Estado
        /// </summary>
        [Required]
        [DataMember(Name = "estado")]
        [MaxLength(40)]
        public string Estado { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Endereco {\n");
            sb.Append("  Logradouro: ").Append(Logradouro).Append("\n");
            sb.Append("  Bairro: ").Append(Bairro).Append("\n");
            sb.Append("  Cidade: ").Append(Cidade).Append("\n");
            sb.Append("  Estado: ").Append(Estado).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
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
            return obj.GetType() == GetType() && Equals((EnderecoModel)obj);
        }

        /// <summary>
        /// Returns true if Endereco instances are equal
        /// </summary>
        /// <param name="other">Instance of Endereco to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EnderecoModel other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Logradouro == other.Logradouro ||
                    Logradouro != null &&
                    Logradouro.Equals(other.Logradouro)
                ) &&
                (
                    Bairro == other.Bairro ||
                    Bairro != null &&
                    Bairro.Equals(other.Bairro)
                ) &&
                (
                    Cidade == other.Cidade ||
                    Cidade != null &&
                    Cidade.Equals(other.Cidade)
                ) &&
                (
                    Estado == other.Estado ||
                    Estado != null &&
                    Estado.Equals(other.Estado)
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
                if (Logradouro != null)
                    hashCode = hashCode * 59 + Logradouro.GetHashCode();
                if (Bairro != null)
                    hashCode = hashCode * 59 + Bairro.GetHashCode();
                if (Cidade != null)
                    hashCode = hashCode * 59 + Cidade.GetHashCode();
                if (Estado != null)
                    hashCode = hashCode * 59 + Estado.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(EnderecoModel left, EnderecoModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EnderecoModel left, EnderecoModel right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
