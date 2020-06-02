import React from 'react';
import Route from 'react-router-dom/Route';
import Switch from 'react-router-dom/Switch';
import loadable from '@loadable/component'
import './App.css';

const HeroList = loadable(() => import('./HeroList'))
const HeroDetail = loadable(() => import('./HeroDetail'))

const App = () => (
  <Switch>
    <Route exact path="/" component={HeroList} />
    <Route exact path="/:id" component={HeroDetail} />
  </Switch>
);

export default App;
