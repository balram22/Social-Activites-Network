import { useEffect, useState } from 'react'
import './App.css'
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    getActivities();
  }, [])

  const getActivities = async () => {
    var response = await axios.get("http://localhost:5000/api/activities")
    setActivities(response.data);
  }

  return (
    <>
      <Header as={'h2'} icon={'users'} content='Reactivities' />
      <List>
        {activities.map((activity: any) => (
          <List.Item key={activity.title}>
            {activity.title}
          </List.Item>
        ))}
      </List>
    </>
  )
}

export default App
