import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import WelcomePage from './Components/WelcomePage';
import UtilisateurPage from './Components/UtilisateurPage';
import HeadMenu from './Components/HeadMenu';
import SideMenu from './Components/SideMenu';
import ProjectForm from './Components/NouveauProjet';
import ProjetPage from './Components/ProjetPage';
import './App.css';
import { PostProjets } from './Services/ProjetService';
import { Projet } from './Models/ProjetModel';
import { HTML5Backend } from 'react-dnd-html5-backend';
import { DndProvider } from 'react-dnd';


function App() {

  const handleFormSubmit = (formData: Projet) => {
    try {
      // Make a POST request to your API endpoint
      const response = PostProjets(formData);

      // Handle the response as needed
      console.log('API Response:', response);

      

    } catch (error) {
      // Handle errors
      console.error('API Error:', error);

      // You can also perform additional actions on error
    }

    console.log('Form submitted:', formData);
  };


  return (
    <DndProvider backend={HTML5Backend}>
    <Router>

      <HeadMenu/>

      <SideMenu/>

      {/* Page Content */}
      <main>
        <Routes>
          <Route path="/" element={<WelcomePage />} />
          <Route path="/Utilisateur" element={<UtilisateurPage />} />
          <Route path="/NouveauProjet" element={<ProjectForm onSubmit={handleFormSubmit} />} />
          <Route path="/Utilisateur" element={<UtilisateurPage />} />
          <Route path="/Projet/:idProjet" element={<ProjetPage/>} />
        </Routes>
      </main>
    </Router>
    </DndProvider>
  );
}

export default App;
