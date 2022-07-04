import { StyleSheet, Text, View } from 'react-native';
import axios from 'axios';
import {react, Component} from 'react';

// https://developer.marvel.com/documentation/entity_types

axios({
    method: 'get',
    url: ' http://gateway.marvel.com/v1/public/characters?ts=jdklsfjdl&apikey=4973292c7399b338929b4e9148fb35ee&hash=92aae9d46761a9618e02c98e6d987190&',
    params: {
      name: 'Deadpool',
    }
  }).then(function (response) {
    console.log(response.data); 
  });
