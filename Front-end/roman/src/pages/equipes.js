import React, { Component } from 'react';
import {StyleSheet, Text, TextInput, View, TouchableOpacity} from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Equipes extends Component {
    constructor(props){
        super(props);
        this.state = {
            
        }
    }
    render(){
        return(
            <View style={styles.body}>
                <View style={styles.container}>
                    <View style={styles.equipes}>
                        <View style={styles.alinharEquipes} >
                            <View style={styles.tituloEquip}>
                                <h2>Equipe1</h2>
                            </View>
                            <View style={styles.botaoEquipe}>
                                <button type="button">entrar</button>
                            </View>
                        </View>
                    </View>
                </View>
            </View>
        );
    }
}

const styles = StyleSheet.create({

    body: {
        width: '100%',
        justifyContent: 'center',
        alignItems: 'center',
    },

    container: {
        width: 290,
        margin: 0,
        justifyContent: 'center',
    },

    equipes: {
        width: 290,
        height: 49,
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#048ABF',
        borderRadius: 5,
        marginBottom: 15,
    },

    alinharEquipes: {
        fontSize: 18,
        color: 'white',
        width: 257,
        flexDirection: 'row',
        alignItems: 'center',
        justifyContent: 'space-between',
    },

    tituloEquipe: {
        paddingTop: 15,
    },

    botaoEquipe: {
        paddingTop: 6,
    },
})