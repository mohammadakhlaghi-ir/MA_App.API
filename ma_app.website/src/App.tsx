import { useEffect, useState } from 'react';
import axios from 'axios';

type AppInfoDto = {
  title: string;
  description: string;
};

function App() {
  const [appInfo, setAppInfo] = useState<AppInfoDto | null>(null);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    axios.get<AppInfoDto>(`${import.meta.env.VITE_API_BASE_URL}/api/Home/GetAppInfo`)
      .then(response => {
        setAppInfo(response.data);
      })
      .catch(error => {
        console.error('Error fetching app info:', error);
        if (error.response) {
          console.error("Backend responded with:", error.response.data);
        }
        setError('Failed to load app info');
      });
  }, []);
  console.log(appInfo)
  return (
    <div>
      <h1>App Info</h1>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      {appInfo ? (
        <div>
          <p><strong>Name:</strong> {appInfo.title}</p>
          <p><strong>Description:</strong> {appInfo.description}</p>
        </div>
      ) : (
        !error && <p>Loading app info...</p>
      )}
    </div>
  );
}

export default App;
