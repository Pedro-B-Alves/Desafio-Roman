import React, { Component } from 'react';
import {StyleSheet, Text, TextInput, View, TouchableOpacity} from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email : 'adm@gmail.com',
            senha : 'adm123',
            erro: '',
        }
    }

    realizarLogin = async () => {
        try 
        {
            const resposta = await api.post('/Login', {
                email : this.state.email,
                senha : this.state.senha
            });
   
            const token = resposta.data.token;
   
            await AsyncStorage.setItem('userToken', token);

            this.props.navigation.navigate('Main');
        } 

        catch (error) 
        {
            this.setState({erro : 'Email ou senha incorretos'})
        }
         

    }

    render(){
        return(
            <View style={styles.body}>
                <View style={styles.main}>
                    <Text style={styles.tituloRoman}>Roman</Text>
                    <View style={styles.BlocoLogin}>
                        <View style={styles.alinhamentoLogin}>
                            <View style={styles.titLogin}>
                                <Text style={styles.titLogin}>Login</Text>
                            </View>
                            <View style={styles.campoLogin}>
                                <Text style={styles.email}>Email</Text>
                                <TextInput
                                    style={styles.digitar}
                                    keyboardType='email-address'
                                    onChangeText={email => this.setState({ email })}
                                />
                            </View>
                            <View style={styles.campoLogin}>
                                <Text style={styles.email}>Senha</Text>
                                <TextInput
                                    style={styles.digitar}
                                    secureTextEntry={true}
                                    onChangeText={senha => this.setState({ senha })}
                                />
                            </View>
                            <View style={styles.botaoLogin}>
                                <TouchableOpacity
                                    onPress={this.realizarLogin}>
                                    <Text style={styles.botaoEntrar}>Entrar</Text>
                                </TouchableOpacity>

                                <Text style={styles.erro}>{this.state.erro}</Text>
                                
                                <TouchableOpacity
                                    onPress={this.cadastrar}>
                                    <Text>cadastrar</Text>
                                </TouchableOpacity>
                            </View>
                        </View>
                    </View>
                </View>
            </View>
        );
    }
}

const styles = StyleSheet.create({

    erro:{
        color: 'red',
    },

    body:{
        width: '100%',
        justifyContent: 'center',
        alignItems: 'center',
    },

    main: {
        width: 290,
        margin: 0,
        marginTop: 100,
        justifyContent: 'center',
    },

    BlocoLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        width: '250',
        height: 514,
        backgroundColor: '#048ABF',
        border: 'solid 1px black',
        borderRadius: 5,
    },

    email:{
        textTransform: 'uppercase', 
        color: 'white',
        fontSize: 'bolder',

    },

    alinhamentoLogin: {
        width: 200,
        height: '100%',
        flexDirection: 'column',
        alignTtems: 'center',
    },

    titLogin: {
        justifyContent: 'center',
        marginTop: 45,
        marginBottom: 45,
        width: '100%',
        color: 'white',
        fontStyle: 'normal',
        fontWeight: 'bolder',
        fontSize: 24,
        lineHeight: 28,
        textAlign: 'center',
        textTransform: 'uppercase',
    },

    campoLogin: {
        width: '100%',
        height: 'auto',
        marginBottom: 45,
    },

    tituloRoman: {
        fontStyle: 'normal',
        fontWeight: 800,
        fontSize: 48,
        lineHeight: 106,
        textAlign: 'center',
        color: '#03588C',
        marginTop: -80,
        marginBottom: 35,
        textTransform: "uppercase",
    },

    botaoLogin: {
        width: '100%',
        height: 102,
        justifyContent: 'cente',
        alignItems: 'center',
        flexDirection: 'column',
    },

    digitar:{
        color: 'white',
        width: '100%',
        border: 'solid 1px white',
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