import React, { useState, useEffect } from 'react';
import { Formik, Form, Field, FieldArray, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import { Projet} from '../Models/ProjetModel';
import '../Styles/NouveauProjet.css';
import {getUtilisateur} from '../Services/UtilisateurService';
import { Utilisateur } from '../Models/UtilisateurModel';
import getDate from 'date-fns/getDate';

interface ProjectFormProps {
  onSubmit: (project: Projet) => void;
}

const ProjectForm: React.FC<ProjectFormProps> = ({ onSubmit }) => {
  const initialValues: Projet = {
    idProjet: '',
    nomProjet: '',
    dateDebut: new Date(),
    dateFin: new Date(),
    objectifProjets: [],
    taches: [],
    idStatuts: [],
    idUtilisateurs: [],
  };

  const validationSchema = Yup.object({
    nomProjet: Yup.string().required('Required')
  });

  const handleSubmit = (values: Projet) => {
    onSubmit(values);
  };

  const [utilisateurs, setUtilisateurs] = useState<Utilisateur[]>([]);

  useEffect(() => {
      /*Appele APi pour les projets*/ 
      const fetchUtilisateurs = async () => {

        try {
  
          const response = await getUtilisateur();
          if (response && response.data) {
          const ApiProjet= response.data;

          setUtilisateurs(ApiProjet);
          }else {
            console.error('Invalid response:', response);
          }
  
        } catch (error) {
  
          console.error('Error fetching projets:', error);
  
        }
      };
  
      fetchUtilisateurs();

  }, []);

  return (
    <div className="form-container">
    <Formik
      initialValues={initialValues}
      validationSchema={validationSchema}
      onSubmit={handleSubmit}
    >
        {({ values }) => (
      <Form className="your-form">
        <div className="form-field">
          <label className="label-style" htmlFor="nomProjet">Project Name</label>
          <Field className="field-style" type="text" id="nomProjet" name="nomProjet" />
          <ErrorMessage name="nomProjet" component="div" />
        </div>

        <div className="form-field">
          <label className="label-style" htmlFor="dateDebut">Date début</label>
          <Field className="field-style" type="text" id="dateDebut" name="dateDebut" />
          <ErrorMessage name="dateDebut" component="div" />
        </div>

        <div className="form-field">
          <label className="label-style" htmlFor="dateFin">Date Fin</label>
          <Field className="field-style" type="text" id="dateFin" name="dateFin" />
          <ErrorMessage name="dateFin" component="div" />
        </div>

        {/* Objectives */}
        <div className="form-field2">
          <label className="label-style2">Objectifs</label>
          <FieldArray name="objectifProjets">
            {({ push, remove }) => (
              <div>
                {values.objectifProjets.map((_, index) => (
                  <div key={index}>
                    <div className="form-field">
                    <Field
                      type="text"
                      name={`objectifProjets.${index}.descriptionObjectifProjet`}
                      className="field-style"
                    />
                    <button type="button" onClick={() => remove(index)}>
                      Supprimer
                    </button>
                    </div>
                  </div>
                ))}
                <button
                  type="button"
                  onClick={() => push({ idObjectifProjet: '', descriptionObjectifProjet: '', complete: false })}
                >
                  Ajouter
                </button>
              </div>
            )}
          </FieldArray>
        </div>

        {/* Users */}
        <div className="form-field2">
          <label className="label-style2">Membres d'équipe</label>
          <FieldArray name="utilisateurs">
            {({ push, remove }) => (
              <div>
                {values.idUtilisateurs.map((_, index) => (
                  <div key={index}>
                    <div className="form-field">
                    <Field
                            as="select"
                            name={`utilisateurs.${index}`}
                            className="field-style"
                          >
                            <option value="" disabled>Select a user</option>
                            {utilisateurs.map((user: Utilisateur, userIndex) => (
                              <option key={userIndex} value={user.nom}>
                                {user.nom}{user.prenom}
                              </option>
                            ))}
                          </Field>
                    <button type="button" onClick={() => remove(index)}>
                      Supprimer
                    </button>
                    </div>
                  </div>
                ))}
                <button
                  type="button"
                  onClick={() => push({ idUtilisateur: '', nom: '', prenom: '' })}
                >
                  Ajouter
                </button>
              </div>
            )}
          </FieldArray>
        </div>

        <button type="submit">Submit</button>
      </Form>
        )}
    </Formik>
   </div>
  );
};

export default ProjectForm;
