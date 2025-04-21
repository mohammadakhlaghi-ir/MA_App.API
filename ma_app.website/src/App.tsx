import { useEffect, useState } from "react";
import axios from "axios";

var apiUrl = import.meta.env.VITE_API_BASE_URL;

type AppInfoDto = {
  title: string;
  description?: string;
  favicon: string;
  logo: string;
  language: string;
  created: string;
  modifyDate?: string;
};

function App() {
  const [appInfo, setAppInfo] = useState<AppInfoDto | null>(null);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    axios
      .get<AppInfoDto>(apiUrl + "/api/Home/GetAppInfo")
      .then((response) => {
        const info = response.data;
        setAppInfo(info);
        document.title = info.title;
        document.documentElement.lang = info.language;

        const link: HTMLLinkElement | null =
          document.querySelector("link[rel*='icon']");
        if (info) {
          if (link) {
            link.href = apiUrl + "/assets/media/appInfo/" + info.favicon;
          } else {
            const newLink = document.createElement("link");
            newLink.rel = "icon";
            newLink.href = apiUrl + "/assets/media/appInfo/" + +info.favicon;
            document.head.appendChild(newLink);
          }
          if (info.description) {
            let metaDescription = document.querySelector(
              "meta[name='description']"
            );
            if (!metaDescription) {
              metaDescription = document.createElement("meta");
              metaDescription.setAttribute("name", "description");
              document.head.appendChild(metaDescription);
            }
            metaDescription.setAttribute("content", info.description);
          }
        }
      })
      .catch((error) => {
        console.error("Error fetching app info:", error);
        if (error.response) {
          console.error("Backend responded with:", error.response.data);
        }
        setError("Failed to load app info");
      });
  }, []);
  return (
    <div>
      {!appInfo && !error ? (
        <div>
          <h1>Loading...</h1>
        </div>
      ) : error ? (
        <p style={{ color: "red" }}>{error}</p>
      ) : (
        <div>
          <h1>App Info</h1>
          <p>
            <strong>Name:</strong> {appInfo?.title}
          </p>
          <p>
            <strong>Description:</strong> {appInfo?.description}
          </p>
        </div>
      )}
    </div>
  );
}

export default App;
