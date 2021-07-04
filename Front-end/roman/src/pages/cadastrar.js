import React, { Component } from 'react';
import {StyleSheet, Text, TextInput, View, TouchableOpacity} from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import jwtDecode from 'jwt-decode';

import api from '../services/api';

export default class Cadastrar extends Component {
    constructor(props){
        super(props);
        this.state = {
            idAtividade: '1',
            idUsuario: '',
            tema: '',
            projeto1: '',
            descricao: '',
            erro : '',
            sucesso : '',
        }
    }

    cadastrarProjeto = async () => {

        const valorToken = await AsyncStorage.getItem('userToken');
        this.setState({idUsuario : jwtDecode(valorToken).idUsuario})
        
        try {
            const resposta = await api.post('/Projeto',{
                idAtividade     : this.state.idAtividade,
                idUsuario       : this.state.idUsuario,
                tema            : this.state.tema,
                projeto         : this.state.projeto,
                descricao       : this.state.descricao,
            })
        } catch (error) {
            this.setState({erro : 'Erro na api'})
        }

        this.setState({sucesso : 'Projeto enviado!'})
        
    }

    render(){
        return(
            <View style={styles.body}>
                <View style={styles.container}>
                    <View style={styles.formCadastrar}>
                        <View style={styles.campoTema}>
                            <Text style={styles.campoTemaP}>Tema</Text>
                            <TextInput
                                style={styles.campoTemaI}
                                keyboardType='text'
                                onChangeText={tema => this.setState({ tema })}
                            />
                        </View>
                        <View style={styles.campoTema}>
                            <Text style={styles.campoTemaP}>Projeto</Text>
                            <TextInput
                                style={styles.campoTemaI}
                                keyboardType='text'
                                onChangeText={projeto => this.setState({ projeto })}
                            />
                        </View>
                        <View style={styles.campoDescricao}>
                            <Text style={styles.campoTemaP}>Descracao</Text>
                            <TextInput
                                style={styles.campoTemaI}
                                keyboardType='text'
                                onChangeText={descracao => this.setState({ descracao })}
                            />
                        </View>
                        <View style={styles.viewBotao}>
                            <TouchableOpacity
                                onPress={this.cadastrarProjeto}
                            >
                                <Text style={styles.botaoEntrar}>Cadastrar</Text>
                            </TouchableOpacity>
                        </View>
                        <Text style={styles.erro}>{this.state.erro}</Text>
                        <Text style={styles.sucesso}>{this.state.sucesso}</Text>
                    </View>
                </View>
            </View>
        );
    }
}

const styles = StyleSheet.create({

    body: {
        width: '100%',
        height: '100%',
        justifyContent: 'center',
        alignItems: 'center',
    },

    erro: {
        color: 'red',
    },

    sucesso: {
        color: 'gren',
    },

    container: {
        width: 290,
        margin: 0,
        justifyContent: 'center',
    },

    formCadastrar: {
        flexDirection: 'column',
        justifyContent: 'center',
        width: '100%',
        height: 493,
        marginTop: 100,
        marginBottom: 107,
    },

    campoTema: {
        width: '100%',
        height: 60,
        margiBottom: 20,
    },

    campoTemaP: {
        textTransform: 'uppercase',
        fontFamily: 'Roboto',
        fontWeight: 'bolder',
        marginBottom: 7,
    },

    campoTemaI: {
        width: '100%',
        height: 20,
        border: 'none',
        border: 'solid 1px #03588C',
    },

    viewBotao: {
        width: '100%',
        justifyContent: 'center',
        alignItems: 'center',
        marginTop: 50,
    },

    botaoEntrar: {
        textAlign: 'center',
        paddingTop: 8.5,
        textTransform: 'uppercase',
        width: 150,
        height: 41,
        backgroundColor: '#03588C',
        color: 'white',
        border: 'solid 1px white',
        borderRadius: 5,
        fontFamily: 'Roboto',
        fontWeight: 'bolder',
        fontSize: 18,
        marginBottom: 30,
    }
})