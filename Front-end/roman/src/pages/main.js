import React, { Component } from 'react';
import { StyleSheet, View, Image } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import Listar from './listar';
import Cadastrar from './cadastrar';
import Equipes from './equipes';

const bottomTab = createBottomTabNavigator();

export default class Main extends Component {

  render(){
    return (
      <View style={styles.main}>
        <bottomTab.Navigator
            initialRouteName= 'Listar'
            tabBarOptions={{
                showLabel: false,
                showIcon: true,
                activeBackgroundColor: '#03588C',
                inactiveBackgroundColor: '#048ABF'
            }}
            screenOptions = { ({ route })  => ({
                tabBarIcon : () => {
                    if (route.name === 'Listar') {
                        return(
                        <Image
                            source={require('../../assets/images/simbolo-da-lista-branca.png')}
                            style={styles.icon}
                        />
                        )
                    }
                    if (route.name === 'Cadastrar') {
                        return(
                        <Image
                            source={require('../../assets/images/escreve-carta-branca.png')}
                            style={styles.icon}
                        />
                        )
                    }
                    if (route.name === 'Equipes') {
                        return(
                        <Image
                            source={require('../../assets/images/icon-grupo.png')}
                            style={styles.icon}
                        />
                        )
                    }
                }
            })
        }
        >
        <bottomTab.Screen name="Equipes" component={Equipes} />
        <bottomTab.Screen name="Listar" component={Listar} />
        <bottomTab.Screen name="Cadastrar" component={Cadastrar} />
        </bottomTab.Navigator>
      </View>
    );
  }
}

const styles = StyleSheet.create({

  main: {
    flex: 1,
    width: '100%',
    height: 70,
    justifyContent: 'space-between',
  },

  icon: {
      width : 33,
      height : 33,
  }
});