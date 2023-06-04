import * as ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import configureStore from './store/configureStore';
import Rutas from './routes';

import { createRoot } from 'react-dom/client';
const container = document.getElementById('root');
const root = createRoot(container!);
const store = configureStore();

root.render(<Provider store={store}>
  <BrowserRouter>
      <Rutas />
  </BrowserRouter>
</Provider>);