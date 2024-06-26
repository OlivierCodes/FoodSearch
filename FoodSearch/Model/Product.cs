﻿
using System.Text.Json.Serialization;

namespace FoodSearch.Model;

public class Product
{
    public string Code { get; set; }
    public string Url { get; set; }
    [JsonPropertyName("product_name")]
    public string ProductName { get; set; }

    public string GenericName { get; set; }

    public string Quantity { get; set; }
    [JsonPropertyName("ingredients_text")]
    public string IngredientsText { get; set; }

    public string Brands { get; set; }

    [JsonPropertyName("nutriscore_grade")]
    public string NutriScoreGrade { get; set; }

    public string NutriScoreGradeImage 
    {
        get => $"nutriscore_{NutriScoreGrade}.png";
    }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

}

