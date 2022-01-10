using System;

namespace RiskOfPotentialAsteroids.DOM
{
    [Serializable]
    public class AsteroidDto
    {
        public string Nombre { get; set; } // nombre: Obtenido de "name",

        public double Diametro { get; set; } // diametro: Tamaño medio calculado

        public string Velocidad { get; set; } // velocidad: "close_approach_data:relative_velocity:kilometers_per_hour"

        public DateTime Fecha { get; set; } // fecha: "close_approach_data:close_approach_date"

        public string Planeta { get; set; } // planeta: "close_approach_date:orbiting_body"
    }
}
