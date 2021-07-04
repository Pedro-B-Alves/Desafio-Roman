import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

import Login from './src/pages/login';
import Main from './src/pages/main';

const AuthStack = createStackNavigator();

export default function Stak(){
  return(
    <NavigationContainer>
      <AuthStack.Navigator>
        <AuthStack.Screen name = 'Login' component={Login}/>
        <AuthStack.Screen name = 'Main' component={Main}/>
      </AuthStack.Navigator>
    </NavigationContainer>
  )
}
