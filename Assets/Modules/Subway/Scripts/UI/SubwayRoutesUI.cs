using System.Linq;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Subway.UI
{
    public class SubwayRoutesUI : MonoBehaviour
    {
        [SerializeField] private Dropdown _origin;
        [SerializeField] private Dropdown _destination;
        [SerializeField] private Button _checkBtn;
        [SerializeField] private Text _ouputText;

        private SubwayRoutesFinder _finder = new();
        private IReadOnlyList<SubwayStation> _stations;

        private void Start()
        {
            var stations = new List<SubwayStation>();
            var options = new List<string>();
            foreach (var station in _finder.Stations)
            {
                stations.Add(station);
                options.Add(station.Name);
            }
            _stations = stations;

            _origin.ClearOptions();
            _destination.ClearOptions();
            _origin.AddOptions(options);
            _destination.AddOptions(options);

            _checkBtn.onClick.AddListener(RefreshOutput);
        }

        private void RefreshOutput()
        {
            var path = _finder.GetPath(GetStation(_origin), GetStation(_destination), out int transfers);
            _ouputText.text = FormOutput(path, transfers);
        }

        private string FormOutput(IReadOnlyList<SubwayStation> path, int transfers)
        {
            var sb = new StringBuilder();
            sb.Append("Path: ");
            foreach (var station in path)
            {
                sb.Append(station.Name);
                sb.Append(", ");
            }
            sb.AppendLine();
            sb.Append("Transfers: ");
            sb.Append(transfers);
            return sb.ToString();
        }

        private SubwayStation GetStation(Dropdown dropdown)
        {
            return _stations[dropdown.value];
        }
    }
}