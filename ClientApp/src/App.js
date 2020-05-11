import React from 'react';
import Route from 'react-router-dom/Route';
import Switch from 'react-router-dom/Switch';
import './App.css';
import HeroList from './HeroList';
import HeroDetail from './HeroDetail';

const App = () => (
  <Switch>
    <Route exact path="/" component={HeroList} />
    <Route exact path="/:id" component={HeroDetail} />
  </Switch>
);

export default App;
