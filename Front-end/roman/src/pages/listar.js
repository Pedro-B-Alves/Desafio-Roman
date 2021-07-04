import React, { Component } from 'react';
import { FlatList,StyleSheet, Text, TextInput, View, TouchableOpacity} from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import jwtDecode from 'jwt-decode';

import api from '../services/api';

export default class Listar extends Component {
    constructor(props){
        super(props);
        this.state = {
            listaProjetos: [],
            erro: '',
        }
    }

    buscarProjeto = async () => {
        try {
            const resposta = await api.get('/Projeto')
            const dataApi = resposta.data;
            this.setState({ listaProjetos : dataApi })
        } catch (error) {
            this.setState({erro : 'Erro na api...'})
        }
        
    }

    componentDidMount(){
        this.buscarProjeto()
    }

    render(){
        return(
            <View style={styles.body}>
                <View style={styles.container}>
                    <FlatList
                        data={ this.state.listaProjetos}
                        keyExtractor={item => item.idProjeto}
                        renderItem={this.renderItem}
                    />
                </View>
            </View>
        );

    }
    renderItem = ({ item }) => (
        <View style={styles.blocoTema}>
            <View style={styles.tema}>
                <Text>{item.tema}</Text>
            </View>
            <View style={styles.descricaoProjeto}>
                <View style={styles.projeto}>
                    <Text>{item.projeto1}</Text> 
                </View>
                <View style={styles.descricao}>
                    <Text>{item.descricao}</Text>
                </View>
            </View>
        </View>
    )
}

const styles = StyleSheet.create({

    body:{
        width: '100%',
        alignItems: 'center',
    },

    container: {
        width: 290,
        margin: 0,
        justifyContent: 'center',
    },

    blocoTema: {
        width: 290,
        height: 292,
        flexDirection: 'column',
        fontFamily: 'Roboto Bold',
        alignItems: 'center',
        marginTop: 22,
        marginBottom: 22,
    },

    tema: {
        width: '100%',
        height: 53,
        backgroundColor: '#048ABF',
        border: 'solid 1',
        borderRadius: 5,
        justifyContent: 'center',
        alignItems: 'center',
        fontSize: 14,
        paddingTop: 15,
        color: 'white',
    },

    descricaoProjeto: {
        width: 290,
        height: 239,
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#049DBF',
    },

    projeto: {
        width: 224,
        height: 65,
        justifyContent: 'center',
        alignItems: 'center',
        color: 'white',
        marginBottom: 27,
        paddingTop: 10,
    },

    descricao: {
        width: 224,
        height: 174,
        flexDirection: 'column',
        justifyContent: 'center',
        color: 'white',
        fontWeight: 'bolder',
    },
})