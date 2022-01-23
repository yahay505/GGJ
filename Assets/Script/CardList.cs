using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script
{
    public class CardList : MonoBehaviour
    {
        private List<Card> AllCards
        {
            get
            {
                // _cards ??= GetAllInstances<Card>();
                return _cards;
            }
        }

        public List<Card> _cards;


        private void Start()
        {
            Debug.Log(AllCards);
        }

        public Card GetRandomCard()
        {
            return AllCards[Random.Range(0, AllCards.Count)];
        }
        /// <summary>
        /// Get all instances of scriptable objects with given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        // public static List<T> GetAllInstances<T>() where T : ScriptableObject
        // {
        //     return AssetDatabase.FindAssets($"t: {typeof(T).Name}").ToList()
        //         .Select(AssetDatabase.GUIDToAssetPath)
        //         .Select(AssetDatabase.LoadAssetAtPath<T>)
        //         .ToList();
        // }
    }
}